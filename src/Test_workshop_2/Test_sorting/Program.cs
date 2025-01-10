

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
        space[i, 0] = space[i, 0] + space[i - 1, 0];
    }
    for (int i = 1; i < space.GetLength(1); i++)
    {
        space[0, i] = space[0, i] + space[0, i - 1];
    }

    for (int i = 1; i < space.GetLength(0); i++)
    {
        for (int j = 1; j < space.GetLength(1); j++)
        {
            space[i, j] = Math.Min(
                space[i - 1, j] + space[i, j],
                space[i, j - 1] + space[i, j]);
        }
    }

    PrintArray(space);
    Console.WriteLine();

    return PrintPath(ReversePath(space));
}

void PrintArray(int[,] space)
{
    for (int i = 0; i < space.GetLength(0); i++)
    {
        for (int j = 0; j < space.GetLength(1); j++)
        {
            Console.Write(space[i,j] + " ");
        }
        Console.WriteLine();
    }
    Console.WriteLine();
}

string PrintPath(Stack<(int row, int col)> stack)
{
    StringBuilder sb = new StringBuilder();


    while (stack.Count > 1)
    {
        var item = stack.Pop();
        sb.Append($"({item.row}, {item.col}) -> ");
    }

    var endItem = stack.Pop();
    sb.Append($"({endItem.row}, {endItem.col})");

    return sb.ToString();
}


Stack<(int row, int col)> ReversePath(int[,] space)
{
    Stack<(int row,int col)> stack = new Stack<(int row,int col)> ();

    int row = space.GetLength(0) - 1;
    int col = space.GetLength(1) - 1;

    while (row != 0 && col != 0)
    {
        if (space[row - 1, col] >= space[row, col - 1])
        {
            col--;
        }
        else
        {
            row--;
        }
        stack.Push((row,col));
    }

    return stack;
}