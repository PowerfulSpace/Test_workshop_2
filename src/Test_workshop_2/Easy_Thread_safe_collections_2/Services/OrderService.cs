using Easy_Thread_safe_collections_2.Models;
using System.Collections.Concurrent;

namespace Easy_Thread_safe_collections_2.Services
{
    public class OrderService
    {
        private readonly ConcurrentQueue<Order> _orderQueue;

        public OrderService(ConcurrentQueue<Order> orderQueue)
        {
            _orderQueue = orderQueue;
        }

        // Метод добавления заказов в очередь
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

                _orderQueue.Enqueue(order);
                Console.WriteLine($"Пользователь {userId} добавил заказ: {order.OrderId} ({order.Product})");
                Thread.Sleep(100); // Задержка для имитации времени на оформление заказа
            }
        }

        // Метод обработки заказов
        public void ProcessOrders()
        {
            while (!_orderQueue.IsEmpty)
            {
                if (_orderQueue.TryDequeue(out Order order))
                {
                    // Обработка заказа (например, отправка уведомления)
                    Console.WriteLine($"Заказ {order.OrderId} от {order.Customer} на товар {order.Product} обработан.");
                }
                Thread.Sleep(200); // Задержка для имитации обработки
            }
        }
    }
}
