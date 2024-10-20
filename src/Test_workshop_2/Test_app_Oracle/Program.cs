


// Строка подключения к базе данных
using Oracle.ManagedDataAccess.Client;

string connString = "User Id=SYSTEM;Password=your_password;Data Source=localhost:1521/xe";

// Создаем подключение
using (OracleConnection conn = new OracleConnection(connString))
{
    try
    {
        // Открываем подключение
        conn.Open();
        Console.WriteLine("Подключение к базе данных успешно открыто!");

        // Пример выполнения SQL-запроса
        string sql = "SELECT * FROM employees"; // Пример таблицы
        using (OracleCommand cmd = new OracleCommand(sql, conn))
        {
            using (OracleDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Console.WriteLine("Employee Name: " + reader["name"].ToString());
                }
            }
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine("Ошибка: " + ex.Message);
    }
    finally
    {
        // Закрываем подключение
        conn.Close();
        Console.WriteLine("Подключение закрыто.");
    }
}