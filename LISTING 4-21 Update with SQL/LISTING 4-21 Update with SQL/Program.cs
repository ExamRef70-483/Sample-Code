using System;
using System.Data.SqlClient;


namespace LISTING_4_21_Update_with_SQL
{
    class Program
    {
        static void dumpDatabase(SqlConnection connection)
        {
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

        static void Main(string[] args)
        {
            // You will need to edit this string to match your database file
            string connectionString = "Server=(localdb)\\mssqllocaldb;" +
                "Database=MusicTracksContext-e0f0cd0d-38fe-44a4-add2-359310ff8b5d;" +
                "Trusted_Connection=True;MultipleActiveResultSets=true";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                dumpDatabase(connection);

                SqlCommand command = new SqlCommand("UPDATE MusicTrack SET Artist='Robert Miles' WHERE ID='1'", connection);

                int result = command.ExecuteNonQuery();

                Console.WriteLine("Number of entries updated: {0}", result);

                dumpDatabase(connection);
            }

            Console.ReadKey();
        }
    }
}
