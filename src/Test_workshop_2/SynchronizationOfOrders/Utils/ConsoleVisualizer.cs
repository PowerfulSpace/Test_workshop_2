using SynchronizationOfOrders.Models;

namespace SynchronizationOfOrders.Utils
{
    public class ConsoleVisualizer
    {
        // Метод для вывода сообщения с возможностью настройки цвета
        public void PrintMessage(string message, ConsoleColor color)
        {
            // Сохраняем текущий цвет консоли
            var originalColor = Console.ForegroundColor;

            // Устанавливаем цвет для текущего сообщения
            Console.ForegroundColor = color;

            // Выводим сообщение
            Console.WriteLine(message);

            // Восстанавливаем исходный цвет консоли
            Console.ForegroundColor = originalColor;
        }

        // Метод для визуализации событий (добавление или обработка)
        public void VisualizeOrderAction(int userId, Order order, bool isProcessed)
        {
            if (isProcessed)
            {
                // Если заказ обработан
                PrintMessage($"Заказ {order.OrderId} от {order.Customer} на товар {order.Product} обработан.", ConsoleColor.Green);
            }
            else
            {
                // Если заказ добавлен
                PrintMessage($"Пользователь {userId} добавил заказ: {order.OrderId} ({order.Product})", ConsoleColor.Yellow);
            }
        }
    }
}
