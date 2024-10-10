using Average_TokenGeneration.Models;

namespace Average_TokenGeneration.Services
{
    public static class FileStorage
    {
        private static string filePath = "tasks.txt";

        public static void SaveTasks(List<TaskItem> tasks)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (var task in tasks)
                {
                    writer.WriteLine($"{task.Id}|{task.Title}|{task.IsCompleted}");
                }
            }
            Logger.Log("Tasks saved to file.");
        }

        public static List<TaskItem> LoadTasks()
        {
            var tasks = new List<TaskItem>();
            if (File.Exists(filePath))
            {
                var lines = File.ReadAllLines(filePath);
                foreach (var line in lines)
                {
                    var parts = line.Split('|');
                    var task = new TaskItem(int.Parse(parts[0]), parts[1])
                    {
                        IsCompleted = bool.Parse(parts[2])
                    };
                    tasks.Add(task);
                }
                Logger.Log("Tasks loaded from file.");
            }
            return tasks;
        }
    }
}
