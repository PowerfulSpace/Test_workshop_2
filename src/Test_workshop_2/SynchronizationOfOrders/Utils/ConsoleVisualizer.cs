using SynchronizationOfOrders.Models;

namespace SynchronizationOfOrders.Utils
{
    public class ConsoleVisualizer
    {
        // Приватный метод для вывода сообщения с возможностью настройки цвета
        private void PrintMessage(Func<string> messageFunc, ConsoleColor color)
        {
            var originalColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(messageFunc()); // Вызываем функцию для получения сообщения
            Console.ForegroundColor = originalColor;
        }

        // Метод для визуализации событий (добавление или обработка)
        public void VisualizeOrderAction(int userId, Order order, bool isProcessed)
        {
            if (isProcessed)
            {
                // Используем лямбда-выражение для формирования сообщения
                PrintMessage(() => $"Заказ {order.OrderId} от {order.Customer} на товар {order.Product} обработан.", ConsoleColor.Green);
            }
            else
            {
                PrintMessage(() => $"Пользователь {userId} добавил заказ: {order.OrderId} ({order.Product})", ConsoleColor.Yellow);
            }
        }
    }
}
