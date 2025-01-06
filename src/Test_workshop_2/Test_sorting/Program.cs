
// Создаём граф
Graph graph = new Graph();
graph.AddEdge("A", "B", 1);
graph.AddEdge("A", "C", 4);
graph.AddEdge("B", "C", 2);
graph.AddEdge("B", "D", 6);
graph.AddEdge("C", "D", 3);

// Выводим граф
graph.PrintGraph();

// Передайте граф в метод вашего алгоритма
var adjacencyList = graph.GetAdjacencyList();
int result = FindShortestPath(adjacencyList, "A", "D"); // Ваш алгоритм

Console.WriteLine(result);

Console.ReadLine();

int FindShortestPath(Dictionary<string, List<(string, int)>> graph, string start, string end)
{
    // Расстояния от стартовой вершины до всех остальных
    Dictionary<string, int> distances = new Dictionary<string, int>();
    // Множество посещённых вершин
    HashSet<string> visited = new HashSet<string>();
    // Инициализация
    foreach (var vertex in graph.Keys)
        distances[vertex] = int.MaxValue;

    distances[start] = 0; // Расстояние до самого себя = 0

    while (visited.Count < graph.Count)
    {
        // Выбираем непосещённую вершину с минимальным расстоянием
        string current = null;
        int currentDistance = int.MaxValue;

        foreach (var vertex in distances.Keys)
        {
            if (!visited.Contains(vertex) && distances[vertex] < currentDistance)
            {
                current = vertex;
                currentDistance = distances[vertex];
            }
        }

        if (current == null) // Нет достижимых вершин
            break;

        // Помечаем текущую вершину как посещённую
        visited.Add(current);

        // Обновляем расстояния до соседей
        foreach (var neighbor in graph[current])
        {
            if (!visited.Contains(neighbor.Item1))
            {
                int newDistance = distances[current] + neighbor.Item2;
                if (newDistance < distances[neighbor.Item1])
                    distances[neighbor.Item1] = newDistance;
            }
        }
    }

    // Возвращаем кратчайшее расстояние до целевой вершины
    return distances.ContainsKey(start) ? distances[end] : -1;
}



class Graph
{
    private Dictionary<string, List<(string, int)>> adjacencyList;

    public Graph()
    {
        adjacencyList = new Dictionary<string, List<(string, int)>>();
    }

    // Добавить вершину
    public void AddVertex(string vertex)
    {
        if (!adjacencyList.ContainsKey(vertex))
        {
            adjacencyList[vertex] = new List<(string, int)>();
        }
    }

    // Добавить ребро
    public void AddEdge(string from, string to, int weight)
    {
        if (!adjacencyList.ContainsKey(from))
        {
            AddVertex(from);
        }
        if (!adjacencyList.ContainsKey(to))
        {
            AddVertex(to);
        }

        adjacencyList[from].Add((to, weight));
        adjacencyList[to].Add((from, weight)); // Для неориентированного графа
    }

    // Получить список смежности
    public Dictionary<string, List<(string, int)>> GetAdjacencyList()
    {
        return adjacencyList;
    }

    // Вывести граф
    public void PrintGraph()
    {
        foreach (var vertex in adjacencyList)
        {
            Console.Write($"{vertex.Key}: ");
            foreach (var edge in vertex.Value)
            {
                Console.Write($"({edge.Item1}, {edge.Item2}) ");
            }
            Console.WriteLine();
        }
    }
}

