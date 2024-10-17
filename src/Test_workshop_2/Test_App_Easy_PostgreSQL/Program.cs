using Npgsql;

var connectionString = "Host=localhost;Username=postgres;Password=yourpassword;Database=mydatabase";
using (var connection = new NpgsqlConnection(connectionString))
{
    connection.Open();
    using (var cmd = new NpgsqlCommand("SELECT * FROM mytable", connection))
    {
        using (var reader = cmd.ExecuteReader())
        {
            while (reader.Read())
            {
                Console.WriteLine(reader.GetString(0)); // Чтение первой колонки
            }
        }
    }
}