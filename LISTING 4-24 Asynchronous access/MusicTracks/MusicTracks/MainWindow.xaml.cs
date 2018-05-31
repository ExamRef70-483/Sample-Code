using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Data.SqlClient;

namespace MusicTracks
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        // You will need to edit this string to match your database file
        string connectionString = "Server=(localdb)\\mssqllocaldb;" +
            "Database=MusicTracksContext-e0f0cd0d-38fe-44a4-add2-359310ff8b5d;" +
            "Trusted_Connection=True;MultipleActiveResultSets=true";

        async Task<string> dumpDatabase(SqlConnection connection)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM MusicTrack", connection);

            SqlDataReader reader = await command.ExecuteReaderAsync();

            StringBuilder databaseList = new StringBuilder();

            while (await reader.ReadAsync())
            {
                string id = reader["ID"].ToString();
                string artist = reader["Artist"].ToString();
                string title = reader["Title"].ToString();

                string row = string.Format("ID: {0} Artist: {1} Title: {2}", id, artist, title);
                databaseList.AppendLine(row);
            }

            return databaseList.ToString();
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        private async void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string SqlCommandText = "UPDATE MusicTrack SET Artist=@artist WHERE Title=@searchTitle";

                SqlCommand command = new SqlCommand(SqlCommandText, connection);
                command.Parameters.AddWithValue("@artist", ArtistTextBox.Text);
                command.Parameters.AddWithValue("@searchTitle", TitleTextBox.Text);

                int result = await command.ExecuteNonQueryAsync();
                MessageBox.Show("Number of entries updated: " + result.ToString());

                DatabaseTextBlock.Text = await dumpDatabase(connection);
            }
        }

        private async void ViewDatabaseButton_Click(object sender, RoutedEventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                DatabaseTextBlock.Text = await dumpDatabase(connection);
            }
        }
    }
}
