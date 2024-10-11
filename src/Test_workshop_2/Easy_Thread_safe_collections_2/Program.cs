using Easy_Thread_safe_collections_2.Models;
using Easy_Thread_safe_collections_2.Services;
using System.Collections.Concurrent;

// Очередь для хранения заказов
ConcurrentQueue<Order> orderQueue = new ConcurrentQueue<Order>();

// Создание экземпляра OrderService
OrderService orderService = new OrderService(orderQueue);

// Генерация и добавление заказов в очередь
Task[] tasks = new Task[5];

// Имитируем добавление заказов несколькими пользователями
for (int i = 0; i < 3; i++) // 3 потока для добавления заказов
{
    int userId = i + 1;
    tasks[i] = Task.Run(() => orderService.AddOrders(userId));
}

// Обработка заказов
tasks[3] = Task.Run(() => orderService.ProcessOrders());
tasks[4] = Task.Run(() => orderService.ProcessOrders());

// Ждем завершения всех задач
Task.WaitAll(tasks);

Console.WriteLine("Все заказы обработаны!");


Console.ReadLine();