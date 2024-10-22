using MySql.Data.MySqlClient;




string connectionString = "Server=localhost;Database=sampledb;User ID=root;Password=your_password;";

using (var connection = new MySqlConnection(connectionString))
{
    try
    {
        connection.Open();
        Console.WriteLine("Подключение к базе данных успешно!");

        // Вставка данных
        string insertQuery = "INSERT INTO users (name, age) VALUES (@name, @age)";
        using (var command = new MySqlCommand(insertQuery, connection))
        {
            command.Parameters.AddWithValue("@name", "Иван");
            command.Parameters.AddWithValue("@age", 25);

            int rowsAffected = command.ExecuteNonQuery();
            Console.WriteLine($"Добавлено записей: {rowsAffected}");
        }

        // Чтение данных
        string selectQuery = "SELECT * FROM users";
        using (var command = new MySqlCommand(selectQuery, connection))
        {
            using (var reader = command.ExecuteReader())
            {
                Console.WriteLine("Список пользователей:");
                while (reader.Read())
                {
                    Console.WriteLine($"ID: {reader["id"]}, Имя: {reader["name"]}, Возраст: {reader["age"]}");
                }
            }
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Ошибка подключения: {ex.Message}");
    }
}

Console.WriteLine("Программа завершена.");

Console.ReadLine();