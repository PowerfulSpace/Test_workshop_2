
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

    Dictionary<string, int> distances = new Dictionary<string, int>();
    PriorityQueue<string, int> priorityQueue = new PriorityQueue<string, int>();

    foreach (var vertex in graph.Keys)
    {
        distances[vertex] = int.MaxValue;
    }
    distances[start] = 0;


    priorityQueue.Enqueue(start, 0);

    while (priorityQueue.Count > 0)
    {
        string current = priorityQueue.Dequeue();

        if (current == end)
            break;

        foreach (var neighbor in graph[current])
        {
            int newDistance = distances[current] + neighbor.Item2;

            if (newDistance < distances[neighbor.Item1])
            {
                distances[neighbor.Item1] = newDistance;
                priorityQueue.Enqueue(neighbor.Item1, newDistance);
            }
        }
    }

    return distances.ContainsKey(end) ? distances[end] : -1;
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

