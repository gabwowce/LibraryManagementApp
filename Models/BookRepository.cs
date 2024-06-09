using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Threading.Tasks;
using System.Configuration;

namespace LibraryManagementApp.Models
{
    public class BookRepository
    {
        private readonly string connectionString = "your_connection_string_here";

        public async Task<List<Book>> GetBooksByCategoryAsync(string category)
        {
            List<Book> books = new List<Book>();
            using (var connection = new MySqlConnection(connectionString))
            {
                await connection.OpenAsync();
                MySqlCommand command;

                if (category == "All")
                {
                    command = new MySqlCommand("SELECT * FROM Books", connection);
                }
                else
                {
                    command = new MySqlCommand("SELECT * FROM Books WHERE CategoryID = @CategoryID", connection);
                    command.Parameters.AddWithValue("@CategoryID", category); // Assuming category is a valid integer in string form
                }

                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var book = new Book
                        {
                            BookID = reader.IsDBNull(reader.GetOrdinal("BookID")) ? 0 : reader.GetInt32(reader.GetOrdinal("BookID")),
                            Title = reader.IsDBNull(reader.GetOrdinal("Name")) ? string.Empty : reader.GetString(reader.GetOrdinal("Name")),
                            Author = reader.IsDBNull(reader.GetOrdinal("Author")) ? string.Empty : reader.GetString(reader.GetOrdinal("Author")),
                            YearOfRelease = reader.IsDBNull(reader.GetOrdinal("YearOfRelease")) ? 0 : reader.GetInt32(reader.GetOrdinal("YearOfRelease")),
                            CategoryID = reader.IsDBNull(reader.GetOrdinal("CategoryID")) ? 0 : reader.GetInt32(reader.GetOrdinal("CategoryID")),
                            ImageSource = reader.IsDBNull(reader.GetOrdinal("ImagePath")) ? string.Empty : reader.GetString(reader.GetOrdinal("ImagePath")),
                        };
                        books.Add(book);
                    }
                }
            }

            return books;
        }
    }
}
