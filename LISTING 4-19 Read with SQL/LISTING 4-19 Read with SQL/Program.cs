using System;
using System.Data.SqlClient;

namespace LISTING_4_19_Read_with_SQL
{
    class Program
    {
        static void Main(string[] args)
        {
            // You will need to edit this string to match your database file
            string connectionString = "Server=(localdb)\\mssqllocaldb;" +
                "Database=MusicTracksContext-e0f0cd0d-38fe-44a4-add2-359310ff8b5d;" +
                "Trusted_Connection=True;MultipleActiveResultSets=true";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM MusicTrack", connection);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string id = reader["ID"].ToString();
                    string artist = reader["Artist"].ToString();
                    string title = reader["Title"].ToString();

                    Console.WriteLine("ID: {0} Artist: {1} Title: {2}", id, artist, title);
                }
            }

            Console.ReadKey();
        }

    }
}
