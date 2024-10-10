namespace Strong_Authentication.Services
{
    public static class LoggingService
    {
        private static readonly string LogFilePath = "activity.log";

        public static void Log(string message)
        {
            string logMessage = $"{DateTime.Now}: {message}";
            Console.WriteLine(logMessage); // Также выводим в консоль
            File.AppendAllText(LogFilePath, logMessage + Environment.NewLine);
        }
    }
}
