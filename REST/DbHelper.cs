using MySql.Data.MySqlClient;

namespace REST;

public class DbHelper
{
    private static MySqlConnection? _connection;
    private const string ConnectionString = "server=localhost;port=3336;user=root;database=Db;password=1234;";
    private static MySqlDataReader? _currentReader;

    public static MySqlDataReader? ExecuteCommand(string sql)
    {
        _currentReader?.Close();
        _connection = new MySqlConnection(ConnectionString);
        _connection.Open();
        
        var command = new MySqlCommand(sql, _connection);
        _currentReader = command.ExecuteReader();
        return _currentReader;
    }
    

}