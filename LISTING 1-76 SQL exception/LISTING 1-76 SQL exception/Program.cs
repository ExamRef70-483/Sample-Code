using System;
using System.Data.SqlClient;
using System.Text;

namespace LISTING_1_76_SQL_exception
{
    // Note that this program does not create an SQL connection
    // and should not therefore be executed. It shows how to capture and 
    // display the errors from an SQL exception
    class Program
    {
        static void Main(string[] args)
        {
            string queryString = "";

            SqlConnection connection = new SqlConnection();

            SqlCommand command = new SqlCommand(queryString, connection);

            try
            {
                    command.Connection.Open();
                    command.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                StringBuilder message = new StringBuilder();

                foreach(SqlError error in ex.Errors)
                {
                    message.AppendLine("Message: " + error.Message);
                    message.AppendLine("Error number: " + error.Number);
                    message.AppendLine("LineNumber: " + error.LineNumber); 
                    message.AppendLine("Source: " + error.Source);
                    message.AppendLine("Procedure: " + error.Procedure);
                    Console.WriteLine(message);
                }
            }
            catch(InvalidOperationException inv)
            {
                // This exception will be thrown as the 
                // SQL command cannot be built from an invalid
                // connection string
                Console.WriteLine(inv.Message);
            }

            Console.ReadKey();
        }
    }
}
