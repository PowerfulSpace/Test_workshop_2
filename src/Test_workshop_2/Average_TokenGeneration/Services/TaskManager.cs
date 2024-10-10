using Average_TokenGeneration.Models;
using Average_TokenGeneration.Services;

public class TaskManager
{
    private List<TaskItem> _tasks;
    private int _nextId;

    public TaskManager()
    {
        _tasks = new List<TaskItem>();
        _nextId = 1;
    }

    public void AddTask(string title)
    {
        var task = new TaskItem(_nextId, title);
        _tasks.Add(task);
        _nextId++;
        Logger.Log($"Task added: {title}");
    }

    public void RemoveTask(int id)
    {
        var task = _tasks.FirstOrDefault(t => t.Id == id);
        if (task != null)
        {
            _tasks.Remove(task);
            Logger.Log($"Task removed: {task.Title}");
        }
        else
        {
            Console.WriteLine("Task not found.");
        }
    }

    public void MarkTaskAsCompleted(int id)
    {
        var task = _tasks.FirstOrDefault(t => t.Id == id);
        if (task != null)
        {
            task.IsCompleted = true;
            Logger.Log($"Task completed: {task.Title}");
        }
        else
        {
            Console.WriteLine("Task not found.");
        }
    }

    public void ListTasks()
    {
        if (_tasks.Count == 0)
        {
            Console.WriteLine("No tasks available.");
        }
        else
        {
            foreach (var task in _tasks)
            {
                Console.WriteLine(task.ToString());
            }
        }
    }

    public List<TaskItem> GetAllTasks()
    {
        return _tasks;
    }

    // Метод для сохранения задач в файл
    public void SaveTasks()
    {
        var taskStrings = _tasks.Select(task => $"{task.Id},{task.Title},{task.IsCompleted}").ToArray();
        FileStorage.SaveTasks(taskStrings);  // Используем FileStorage для сохранения
        Logger.Log("All tasks saved to file.");
    }

    // Метод для загрузки задач из файла
    public void LoadTasks()
    {
        string[] taskStrings = FileStorage.LoadTasks();
        foreach (var taskString in taskStrings)
        {
            var taskParts = taskString.Split(',');
            if (taskParts.Length == 3)
            {
                int id = int.Parse(taskParts[0]);
                string title = taskParts[1];
                bool isCompleted = bool.Parse(taskParts[2]);

                var task = new TaskItem(id, title, isCompleted);
                _tasks.Add(task);

                // Обновляем _nextId для корректного добавления новых задач
                _nextId = Math.Max(_nextId, id + 1);
            }
        }

        Logger.Log("Tasks loaded from file.");
    }
}