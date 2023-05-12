using Npgsql;

namespace DataAccess;

public static class DatabaseSelector
{
    public static void SelectPersonsWithLetterF(string connectionString)
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            connection.Open();
            
            var createCommand = connection.CreateCommand();
            createCommand.CommandText =
                "SELECT * From \"Persons\" " +
                "WHERE \"FullName\" LIKE 'f%' AND \"Sex\" = 'Male' ";
            
            createCommand.ExecuteNonQuery();

            connection.Close();
        }
    }
}