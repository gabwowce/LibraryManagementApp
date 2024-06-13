﻿using MySql.Data.MySqlClient;
using Org.BouncyCastle.Utilities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementApp.Models
{
    public class MemberRepository
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionToDB"].ConnectionString;

        public async Task<List<Member>> GetMembersAsync()
        {
            List<Member> members = new List<Member>();
            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    await connection.OpenAsync();

                    MySqlCommand command = new MySqlCommand("SELECT * FROM members", connection);
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {

                            var member = new Member
                            {
                                Id = reader.IsDBNull(reader.GetOrdinal("MemberID")) ? 0 : reader.GetInt32(reader.GetOrdinal("MemberID")),
                            Name = reader.IsDBNull(reader.GetOrdinal("Name")) ? string.Empty : reader.GetString(reader.GetOrdinal("Name")),
                                Surname = reader.IsDBNull(reader.GetOrdinal("Surname")) ? string.Empty : reader.GetString(reader.GetOrdinal("Surname")),
                                DateofBirth = reader.IsDBNull(reader.GetOrdinal("DateofBirth")) ? DateTime.MinValue : reader.GetDateTime(reader.GetOrdinal("DateofBirth")),
                            };

                            members.Add(member);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error fetching members: {ex.Message}");
            }

            return members;
        }

       
    }
}
