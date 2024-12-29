
int[,] maze = {
            { 0, 1, 0, 0, 0 },
            { 0, 1, 0, 1, 0 },
            { 0, 0, 0, 1, 0 },
            { 1, 1, 0, 1, 0 },
            { 0, 0, 0, 0, 0 }
        };

var start = (y: 0, x: 0);
var end = (y: 4, x: 4);

Console.WriteLine(GetMinPath(maze, start, end));

Console.ReadLine();


int GetMinPath(int[,] maze,(int y,int x) start, (int y, int x) end)
{
    Queue<(int row, int col, int distance)> queue = new Queue<(int, int, int)>();
    queue.Enqueue(new(start.y, start.x, 0));

    bool[,] vizited = new bool[maze.GetLength(0), maze.GetLength(1)];
    vizited[0, 0] = true;

    int[] dr = { -1, 1, 0, 0 };
    int[] dc = { 0, 0, -1, 1 };

    while(queue.Count > 0)
    {
        (int row, int col, int distance) temp = queue.Dequeue();

        if(temp.row == end.y && temp.col == end.x)
        {
            return temp.distance;
        }

        for (int i = 0; i < 4; i++)
        {
            int newRow = temp.row + dr[i];
            int newCol = temp.col + dc[i];

            if (newRow != 1 && newCol != 1
                && newRow >= 0 && newRow < end.y
                && newCol >= 0 && newCol < end.x
                && !vizited[newRow, newCol])
            {
                queue.Enqueue(new (newRow, newCol,temp.distance + 1));
                vizited[temp.row, temp.col] = true;
            }
        }
    }

    throw new Exception("Не одного пути не было найдено");
}


