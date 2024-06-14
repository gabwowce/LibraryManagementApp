using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementApp.Models
{
    public class HomeViewInformationRepository
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionToDB"].ConnectionString;

        public async Task<HomeViewInformation> GetHomeInformationAsync()
        {
            HomeViewInformation infoForHome = new HomeViewInformation();
            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    await connection.OpenAsync();

                    // Get total books
                    MySqlCommand command = new MySqlCommand("SELECT COUNT(*) AS TotalBooks FROM Books", connection);
                    infoForHome.TotalBooks = Convert.ToInt32(await command.ExecuteScalarAsync());

                    // Get total members
                    infoForHome.TotalMembers = await CountTotalMembersAsync(connection);

                    // Get total books loaned out
                    infoForHome.TotalBooksLoanedOut = await CountTotalBooksLoanedOutAsync(connection);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error fetching Home Information: {ex.Message}");
            }

            return infoForHome;
        }

        private async Task<int> CountTotalMembersAsync(MySqlConnection conn)
        {
            int TotalMembers = 0;
            try
            {
                string sql = "SELECT COUNT(*) FROM Members";
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                     TotalMembers = Convert.ToInt32(await cmd.ExecuteScalarAsync());
                    
                }
            }
            catch
            {
                Debug.WriteLine($"Error fetching Member Information.");
            }
            return TotalMembers;

        }

        private async Task<int> CountTotalBooksLoanedOutAsync(MySqlConnection conn)
        {
            int TotalBooksLoanedOut = 0;

            try
            {
                string sql = "SELECT COUNT(*) FROM Loans";
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    TotalBooksLoanedOut = Convert.ToInt32(await cmd.ExecuteScalarAsync());
                }
            }
            catch
            {
                Debug.WriteLine($"Error fetching Lenden book Information.");
            }
            return TotalBooksLoanedOut;
        }
    }
}
