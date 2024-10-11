using SynchronizationOfOrders.Services;

var orderService = new OrderService();

// Запускаем задачи для добавления и обработки заказов
Task[] tasks = new Task[5];

// Запускаем 3 потока для добавления заказов
for (int i = 0; i < 3; i++)
{
    int userId = i + 1;
    tasks[i] = Task.Run(() => orderService.AddOrders(userId));
}

// Запускаем 2 потока для обработки заказов
tasks[3] = Task.Run(() => orderService.ProcessOrders());
tasks[4] = Task.Run(() => orderService.ProcessOrders());

// Ждем завершения задач по добавлению заказов
Task.WaitAll(tasks[0], tasks[1], tasks[2]);

Console.WriteLine("Все заказы добавлены. Ожидаем завершения обработки...");

// Программа завершитает в бесконечном цикле
Console.ReadLine();тся после закрытия консоли, потому что ProcessOrders рабо
