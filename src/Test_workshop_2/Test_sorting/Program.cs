
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
FindShortestPath(adjacencyList, "A", "D"); // Ваш алгоритм



Console.ReadLine();



void FindShortestPath(Dictionary<string, List<(string, int)>> graph, string start, string end)
{
    // Реализуйте ваш алгоритм здесь
    Console.WriteLine($"Ищем кратчайший путь от {start} до {end}...");
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

