


int[,] maze = {
            { 0, 1, 0, 0, 0 },
            { 0, 1, 0, 1, 0 },
            { 0, 0, 0, 1, 0 },
            { 1, 1, 0, 1, 0 },
            { 0, 0, 0, 0, 0 }
        };

var start = (row: 0, col: 0);
var end = (row: 4, col: 4);


int result = FindShortestPath(maze, start, end);

Console.WriteLine(result == -1 ? "Путь не найден" : $"Минимальное количество шагов: {result}");

Console.ReadLine();


int FindShortestPath(int[,] maze, (int row, int col) start, (int row, int col) end)
{
    int rows = maze.GetLength(0);
    int cols = maze.GetLength(1);

    //  вверх вниз влево вправо
    //  |-1|  |1|  | 0|  |0|
    //  | 0|  |0|  |-1|  |1|
    int[] dr = { -1, 1, 0, 0 };
    int[] dc = { 0, 0, -1, 1 };

    var queue = new Queue<(int row, int col, int distance)>();
    queue.Enqueue((start.row, start.col, 0));

    var visited = new bool[rows, cols];
    visited[start.row, start.col] = true;

    while (queue.Count > 0)
    {
        var (currentRow, currentCol, currentDistance) = queue.Dequeue();

        if (currentRow == end.row && currentCol == end.col)
        {
            return currentDistance;
        }

        for (int i = 0; i < 4; i++)
        {
            int newRow = currentRow + dr[i];
            int newCol = currentCol + dc[i];

            if (newRow >= 0 && newRow < rows
                && newCol >= 0 && newCol < cols
                && maze[newRow, newCol] == 0 && !visited[newRow, newCol])
            {
                queue.Enqueue((newRow, newCol, currentDistance + 1));
                visited[newRow, newCol] = true;
            }
        }


    }

    return -1;
}