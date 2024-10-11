using SynchronizationOfOrders.Models;
using System.Collections.Concurrent;

namespace SynchronizationOfOrders.Services
{
    public class OrderService
    {
        private readonly ConcurrentQueue<Order> _orderQueue = new ConcurrentQueue<Order>();
        private readonly object _lockObject = new object();

        // Метод для добавления заказов в очередь
        public void AddOrders(int userId)
        {
            for (int i = 0; i < 5; i++)
            {
                var order = new Order
                {
                    OrderId = i + 1 + userId * 100,
                    Customer = $"Customer-{userId}",
                    Product = $"Product-{i + 1}"
                };

                lock (_lockObject)
                {
                    _orderQueue.Enqueue(order);
                    Console.WriteLine($"Пользователь {userId} добавил заказ: {order.OrderId} ({order.Product})");

                    // Уведомляем, что появился новый заказ
                    Monitor.Pulse(_lockObject);
                }

                Thread.Sleep(100); // Имитируем задержку для добавления заказов
            }
        }

        // Метод для обработки заказов
        public void ProcessOrders()
        {
            while (true)
            {
                Order? order = null;

                lock (_lockObject)
                {
                    while (_orderQueue.IsEmpty)
                    {
                        // Ожидаем, пока появятся новые заказы
                        Monitor.Wait(_lockObject);
                    }

                    if (_orderQueue.TryDequeue(out order))
                    {
                        // Заказ успешно извлечен
                        Console.WriteLine($"Заказ {order.OrderId} от {order.Customer} на товар {order.Product} обработан.");
                    }
                }

                // Имитируем время обработки заказа
                Thread.Sleep(200);
            }
        }
    }
}
