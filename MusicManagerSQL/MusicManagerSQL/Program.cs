using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicManagerSQL
{
    class Program
    {
        static void Main(string[] args)
        {
            {
                string connectionString = "Server=(localdb)\\mssqllocaldb;" +
                    "Database=MusicManagerContext-a8ff9c26-b3c7-4139-a3fe-c7aeda53ee00;" +
                    "Trusted_Connection=True;MultipleActiveResultSets=true";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand("SELECT * FROM MusicTrack", connection);

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        string title = reader["Title"].ToString();

                        Console.WriteLine("Title: {0}",  title);
                    }
                }
                Console.ReadKey();
            }
        }
    }
}
