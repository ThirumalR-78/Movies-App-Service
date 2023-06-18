using MySqlConnector;

namespace PocketCinemaAPIService
{
    public class DBConnectionManager
    {
        public void OpenDbConnection()
        {
            try
            {

                // Create a new MySqlConnection object.
                var connection = new MySqlConnection("Server=localhost;Port=3306;Database=testing;User=root;Password=root");

                // Open the connection to the database.
                connection.Open();

                var command = new MySqlCommand("SELECT * FROM users", connection);

                // Execute the command against the database.
                var results = command.ExecuteReader();

                // Loop through the results and print the customer names.
                while (results.Read())
                {
                    Console.WriteLine(results["name"]);
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Database connection failed!");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
