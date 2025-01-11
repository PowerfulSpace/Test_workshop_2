
using System.Text;

int[,] space = new int[5, 5]
{
    { 1, 7, 7, 4, 3 },
    { 9, 3, 4, 4, 4 },
    { 6, 9, 7, 9, 3 },
    { 3, 8, 9, 4, 4 },
    { 6, 2, 3, 5, 1 }
};

string result = GetShortestPath(space);
Console.WriteLine(result);

Console.ReadLine();



string GetShortestPath(int[,] space)
{
    for (int i = 1; i < space.GetLength(0); i++)
    {
        space[i, 0] += space[i - 1, 0];
    }
    for (int i = 1; i < space.GetLength(1); i++)
    {
        space[0, i] += space[0, i - 1];
    }

    for (int i = 1; i < space.GetLength(0); i++)
    {
        for (int j = 1; j < space.GetLength(1); j++)
        {
            space[i, j] += Math.Min(space[i - 1, j], space[i, j - 1]);
        }
    }

    var path = RestorePath(space);
    return FormatPath(path);
}

Stack<(int row, int col)> RestorePath(int[,] space)
{
    Stack<(int row, int col)> path = new Stack<(int row, int col)>();
    int row = space.GetLength(0) - 1;
    int col = space.GetLength(1) - 1;

    path.Push((row, col));
    while (row > 0 || col > 0)
    {
        if (row == 0)
        {
            col--;
        }
        else if (col == 0)
        {
            row--;
        }
        else if (space[row - 1, col] <= space[row, col - 1])
        {
            row--;
        }
        else
        {
            col--;
        }
        path.Push((row, col));
    }

    return path;
}

string FormatPath(Stack<(int row, int col)> path)
{
    StringBuilder sb = new StringBuilder();

    while (path.Count > 1)
    {
        var (r, c) = path.Pop();
        sb.Append($"({r}, {c}) -> ");
    }

    var last = path.Pop();
    sb.Append($"({last.row}, {last.col})");

    return sb.ToString();
}
