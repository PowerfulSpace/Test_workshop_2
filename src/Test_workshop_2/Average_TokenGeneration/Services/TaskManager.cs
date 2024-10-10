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
}