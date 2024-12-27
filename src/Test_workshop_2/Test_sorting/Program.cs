


//-1 — это стартовая клетка (S).
//2 — это целевая клетка (T).
//0 — это проходимая клетка.
//1 — это стена.


//int[,] maze = new int[,]
//{
//    { -1, 0, 1, 0, 0 },
//    {  1, 0, 1, 0, 1 },
//    {  0, 0, 1, 0, 0 },
//    {  1, 0, 0, 0, 2 },
//    {  0, 1, 1, 0, 0 } 
//};

int[,] maze = new int[,]
{
    { -1, 1, 0, 1, 1 },
    { 0, 1, 0, 1, 2 },
    { 1, 1, 0, 1, 1 },
    { 0, 1, 1, 1, 0 },
    { 1, 0, 0, 1, 1 }
};

Console.WriteLine(GetTheShortestWay(maze));



Console.ReadLine();


int GetTheShortestWay(int[,] array)
{

    for (int i = 1; i < array.GetLength(0); i++)
    {
        if (array[0, i - 1] == 0)
        {
            array[0, i] = 0;
        }
    }
    for (int i = 1; i < array.GetLength(1); i++)
    {
        if (array[i - 1, 0] == 0)
        {
            array[i,0] = 0;
        }
    }

    for (int i = 1; i < array.GetLength(0); i++)
    {
        for (int j = 1; j < array.GetLength(1); j++)
        {
            if (array[i, j] == 0)
            {
                continue;
            }

            if (array[i - 1, j] == 0 || array[i, j - 1] == 0)
            {
                array[i, j] = array[i - 1, j] + array[i, j - 1];
            }
        }
    }

    return 32;
}