using Npgsql;

namespace DataAccess;

public static class IndexMaker
{
    public static void CreateIndex(string connectionString)
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            connection.Open();
            
            var createCommand = connection.CreateCommand();
            createCommand.CommandText =
                "CREATE INDEX IF NOT EXISTS \"Persons_FullName_idx\" " +
                "ON \"Persons\"( \"FullName\", \"Sex\")";
            
            createCommand.ExecuteNonQuery();
        
            connection.Close();
        }
    }
}