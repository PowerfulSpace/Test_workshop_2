
/// <summary>
/// Главный класс программы
/// </summary>
class Program
{
    // Поля класса
    private static string greetingMessage = "Welcome to the color-coded world of C#!";
    private static int versionNumber = 1;
    private const string AppName = "ColorApp";
    struct Coordinates
    {
        public int X;
        public int Y;
        public Coordinates(int x, int y)
        {
            X = x;
            Y = y;
        }
        public void Display()
        {
            Console.WriteLine($"Coordinates: X={X}, Y={Y}");
        }
    }
    enum Colors
    {
        Red,
        Green,
        Blue
    }

    // Интерфейс
    interface IMessage
    {
        void ShowMessage(string message);
    }

    // Реализация интерфейса в классе
    class ConsoleMessage : IMessage
    {
        public void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }
    }

    /// <summary>
    /// Точка входа в программу
    /// </summary>
    static void Main(string[] args)
    {
        // Локальные переменные
        var name = "User";
        int luckyNumber = 7;

        // Вывод приветственного сообщения
        ConsoleMessage consoleMessage = new ConsoleMessage();
        consoleMessage.ShowMessage($"{greetingMessage} {AppName} v{versionNumber}");

        // Вывод сообщения с использованием строки и числового литерала
        Console.WriteLine($"Hello, {name}! Your lucky number is {luckyNumber}.");

        // Использование структуры
        Coordinates point = new Coordinates(10, 20);
        point.Display();

        // Использование перечисления
        Colors favoriteColor = Colors.Green;
        Console.WriteLine($"Your favorite color is {favoriteColor}.");

        // Завершение программы
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}