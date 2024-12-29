
int[,] maze = {
            { 0, 1, 0, 0, 0 },
            { 0, 1, 0, 1, 0 },
            { 0, 0, 0, 1, 0 },
            { 1, 1, 0, 1, 0 },
            { 0, 0, 0, 0, 0 }
        };

var start = (row: 0, col: 0);
var end = (row: 4, col: 4);

Console.WriteLine(GetMinPath(maze, start, end));

Console.ReadLine();


int GetMinPath(int[,] maze,(int row, int col) start, (int row, int col) end)
{
    Queue<(int row, int col, int distance)> queue = new Queue<(int, int, int)>();
    queue.Enqueue(new(start.row, start.col, 0));

    bool[,] vizited = new bool[maze.GetLength(0), maze.GetLength(1)];
    vizited[0, 0] = true;

    int[] dr = { -1, 1, 0, 0 };
    int[] dc = { 0, 0, -1, 1 };

    while(queue.Count > 0)
    {
        (int row, int col, int distance) temp = queue.Dequeue();

        if(temp.row == end.row && temp.col == end.col)
        {
            return temp.distance;
        }

        for (int i = 0; i < 4; i++)
        {
            int newRow = temp.row + dr[i];
            int newCol = temp.col + dc[i];

            if (newRow >= 0 && newRow <= end.row
                && newCol >= 0 && newCol <= end.col
                && maze[newRow, newCol] != 1 && !vizited[newRow, newCol])
            {
                queue.Enqueue(new (newRow, newCol,temp.distance + 1));
                vizited[newRow, newCol] = true;
            }
        }

        
    }

    return -1;
}


