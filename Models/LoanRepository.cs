using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementApp.Models
{
    public class LoanRepository
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionToDB"].ConnectionString;

        public async Task<List<Loans>> GeLoansAsync()
        {
            List<Loans> loans = new List<Loans>();
            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    await connection.OpenAsync();
                    MySqlCommand command = new MySqlCommand("SELECT * FROM Loans", connection);
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var loan = new Loans
                            {
                                LoanID = reader.IsDBNull(reader.GetOrdinal("LoanID")) ? 0 : reader.GetInt32(reader.GetOrdinal("LoanID")),
                                MemberID = reader.IsDBNull(reader.GetOrdinal("MemberID")) ? 0 : reader.GetInt32(reader.GetOrdinal("MemberID")),
                                BookID = reader.IsDBNull(reader.GetOrdinal("BookID")) ? 0 : reader.GetInt32(reader.GetOrdinal("BookID")),
                                DateofLoan = reader.IsDBNull(reader.GetOrdinal("DateofLoan")) ? DateTime.MinValue : reader.GetDateTime(reader.GetOrdinal("DateofLoan")),
                                EndDate = reader.IsDBNull(reader.GetOrdinal("EndDate")) ? DateTime.MinValue : reader.GetDateTime(reader.GetOrdinal("EndDate")),
                                Status = reader.IsDBNull(reader.GetOrdinal("Status")) ? string.Empty : reader.GetString(reader.GetOrdinal("Status"))
                            };

                            loans.Add(loan);
                        }
                    }

                }
                   
               
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error fetching loans: {ex.Message}");
            }

            return loans;
        }
    }
}
