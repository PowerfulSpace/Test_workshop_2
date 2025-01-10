

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

    return PrintPath(space);
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

string PrintPath(int[,] space)
{
    StringBuilder sb = new StringBuilder();

    int row = space.GetLength(0) - 1;
    int col = space.GetLength(1) - 1;

    sb.Append($"({row}, {col}) -> ");

    while (row != 0 && col != 0)
    {
        if (space[row - 1,col] >= space[row, col - 1])
        {
            col--;
        }
        else
        {
            row--;
        }
        sb.Append($"({row}, {col}) -> ");
    }

    sb.Append($"({0}, {0})");

    return sb.ToString();
}