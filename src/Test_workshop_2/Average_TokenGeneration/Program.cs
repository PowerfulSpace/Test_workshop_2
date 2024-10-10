using Average_TokenGeneration.Services;

var taskManager = new TaskManager();

// Загрузка задач из файла
var savedTasks = FileStorage.LoadTasks();
foreach (var task in savedTasks)
{
    taskManager.AddTask(task.Title);
}

while (true)
{
    Console.WriteLine("\nMenu:");
    Console.WriteLine("1. Add task");
    Console.WriteLine("2. Remove task");
    Console.WriteLine("3. Complete task");
    Console.WriteLine("4. List tasks");
    Console.WriteLine("5. Save and Exit");
    Console.Write("Choose an option: ");

    var choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            Console.Write("Enter task title: ");
            var title = Console.ReadLine();
            taskManager.AddTask(title);
            break;
        case "2":
            Console.Write("Enter task ID to remove: ");
            if (int.TryParse(Console.ReadLine(), out int removeId))
            {
                taskManager.RemoveTask(removeId);
            }
            else
            {
                Console.WriteLine("Invalid ID.");
            }
            break;
        case "3":
            Console.Write("Enter task ID to mark as complete: ");
            if (int.TryParse(Console.ReadLine(), out int completeId))
            {
                taskManager.MarkTaskAsCompleted(completeId);
            }
            else
            {
                Console.WriteLine("Invalid ID.");
            }
            break;
        case "4":
            taskManager.ListTasks();
            break;
        case "5":
            FileStorage.SaveTasks(taskManager.GetAllTasks());
            Console.WriteLine("Tasks saved. Exiting.");
            return;
        default:
            Console.WriteLine("Invalid option. Please try again.");
            break;
    }
}