namespace Average_TokenGeneration.Services
{
    public static class Logger
    {
        private static string logDirectory = "logs";
        private static string logFilePath = Path.Combine(logDirectory, "log.txt");

        public static void Log(string message)
        {
            try
            {
                // Проверяем, существует ли директория для логов, если нет - создаем её
                if (!Directory.Exists(logDirectory))
                {
                    Directory.CreateDirectory(logDirectory);
                }

                // Добавляем текущую дату и время к сообщению
                string logMessage = $"{DateTime.Now}: {message}";

                // Пишем сообщение в файл с логами
                File.AppendAllText(logFilePath, logMessage + Environment.NewLine);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка записи логов: {ex.Message}");
            }
        }
    }
}
