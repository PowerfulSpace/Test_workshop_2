
// Создаём граф
using System.Collections.Immutable;

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

    Dictionary<string, int> distances = new Dictionary<string, int>();
    PriorityQueue<string, int> priorityQueue = new PriorityQueue<string, int>();

    foreach (var item in graph)
    {
        distances[item.Key] = int.MaxValue;
    }

    distances[start] = 0;
    priorityQueue.Enqueue(start, 0);

    while (priorityQueue.Count > 0)
    {
        string current = priorityQueue.Dequeue();

        foreach (var item in graph[current])
        {
            int distance = distances[current] + item.Item2;

            if (distances[item.Item1] > distance)
            {
                distances[item.Item1] = distance;
                priorityQueue.Enqueue(item.Item1,0);
            }

        }
    }

    return distances[end];
}



class Graph
{
    private Dictionary<string, List<(string, int)>> adjacencyList;

    public Graph()
    {
        adjacencyList = new Dictionary<string, List<(string, int)>>();
    }

    public void AddVertex(string vertex)
    {
        if (!adjacencyList.ContainsKey(vertex))
        {
            adjacencyList[vertex] = new List<(string, int)>();
        }
    }

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
        adjacencyList[to].Add((from, weight));
    }

    public Dictionary<string, List<(string, int)>> GetAdjacencyList()
    {
        return adjacencyList;
    }

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

