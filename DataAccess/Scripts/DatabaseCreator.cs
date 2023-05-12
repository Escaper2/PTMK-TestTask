using Npgsql;

namespace DataAccess;

public static class DatabaseCreator
{
    public static void CreateDatabase(string connectionString)
    {
        var builder = new NpgsqlConnectionStringBuilder(connectionString);
        using (var connection = new NpgsqlConnection(builder.ConnectionString))
        {
            connection.Open();
            
            var createCommand = connection.CreateCommand();
            createCommand.CommandText =
                "CREATE TABLE IF NOT EXISTS \"Persons\" (\"PersonId\" uuid, \"FullName\" varchar(100), \"BirthDate\" date, \"Sex\" varchar(10))";
            
            createCommand.ExecuteNonQuery();

            connection.Close();
        }
    }
}