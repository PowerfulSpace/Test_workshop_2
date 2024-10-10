namespace Average_TokenGeneration.Services
{
    public class FileStorage
    {
        private static string dataDirectory = "data";  // Папка для хранения данных
        private static string filePath = Path.Combine(dataDirectory, "tasks.txt");  // Путь к файлу задач

        // Метод для сохранения задач в файл
        public static void SaveTasks(string[] tasks)
        {
            try
            {
                // Проверяем, существует ли директория для хранения данных, если нет - создаем её
                if (!Directory.Exists(dataDirectory))
                {
                    Directory.CreateDirectory(dataDirectory);
                }

                // Записываем задачи в файл
                File.WriteAllLines(filePath, tasks);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при сохранении задач: {ex.Message}");
            }
        }

        // Метод для загрузки задач из файла
        public static string[] LoadTasks()
        {
            try
            {
                // Если файл существует, читаем его содержимое
                if (File.Exists(filePath))
                {
                    return File.ReadAllLines(filePath);
                }
                else
                {
                    return new string[0];  // Возвращаем пустой массив, если файл не найден
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при загрузке задач: {ex.Message}");
                return new string[0];  // В случае ошибки возвращаем пустой массив
            }
        }
    }
}
