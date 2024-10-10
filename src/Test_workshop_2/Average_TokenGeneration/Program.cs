Console.WriteLine("Добро пожаловать в Task Manager!");

// Создаем экземпляр TaskManager для работы с задачами
TaskManager taskManager = new TaskManager();

// Загружаем задачи из файла
taskManager.LoadTasks();

// Выводим задачи, если они есть
taskManager.ListTasks();

while (true)
{
    Console.WriteLine("\nВыберите действие:");
    Console.WriteLine("1. Добавить задачу");
    Console.WriteLine("2. Удалить задачу");
    Console.WriteLine("3. Отметить задачу как выполненную");
    Console.WriteLine("4. Выход");

    string choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            Console.Write("Введите описание задачи: ");
            string taskTitle = Console.ReadLine();
            taskManager.AddTask(taskTitle);
            break;

        case "2":
            Console.Write("Введите ID задачи для удаления: ");
            if (int.TryParse(Console.ReadLine(), out int taskIdToRemove))
            {
                taskManager.RemoveTask(taskIdToRemove);
            }
            else
            {
                Console.WriteLine("Неверный ID задачи.");
            }
            break;

        case "3":
            Console.Write("Введите ID задачи для завершения: ");
            if (int.TryParse(Console.ReadLine(), out int taskIdToComplete))
            {
                taskManager.MarkTaskAsCompleted(taskIdToComplete);
            }
            else
            {
                Console.WriteLine("Неверный ID задачи.");
            }
            break;

        case "4":
            // Сохраняем задачи перед выходом
            taskManager.SaveTasks();
            Console.WriteLine("Задачи сохранены. Выход.");
            return;

        default:
            Console.WriteLine("Неверный выбор. Попробуйте снова.");
            break;
    }
}