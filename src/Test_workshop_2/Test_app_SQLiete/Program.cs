// Указание пути к базе данных (если файла не существует, он будет создан)
string cs = "Data Source=mydatabase.db";

// Создаем подключение к базе данных
using var con = new SQLiteConnection(cs);
con.Open();

// Создаем команду для выполнения SQL-запросов
using var cmd = new SQLiteCommand(con);

// Создание таблицы (если таблица не существует)
cmd.CommandText = @"CREATE TABLE IF NOT EXISTS users(id INTEGER PRIMARY KEY, name TEXT, age INTEGER)";
cmd.ExecuteNonQuery();

// Вставка данных
cmd.CommandText = "INSERT INTO users(name, age) VALUES('Alice', 25)";
cmd.ExecuteNonQuery();

// Запрос данных из таблицы
cmd.CommandText = "SELECT * FROM users";

// Чтение данных
using SQLiteDataReader rdr = cmd.ExecuteReader();

while (rdr.Read())
{
    Console.WriteLine($"{rdr.GetInt32(0)}: {rdr.GetString(1)} - {rdr.GetInt32(2)} years old");
}

con.Close();

Console.ReadLine();