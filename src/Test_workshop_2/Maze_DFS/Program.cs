
int[,] maze = {
            { 0, 0, 1, 0 },
            { 1, 0, 1, 0 },
            { 0, 0, 0, 0 }
        };

var start = (row: 0, col: 0);
var end = (row: 2, col: 3);

bool[,] visited = new bool[maze.GetLength(0), maze.GetLength(1)];

bool pathExists = FindShortestPath(maze, start.row, start.col, end, visited);

Console.WriteLine(pathExists ? "Путь найден!" : "Пути нет.");

Console.ReadLine();

bool FindShortestPath(int[,] maze, int row, int col, (int row, int col) end, bool[,] visited)
{
    // 1. Проверка выхода за границы
    if (row < 0 || row >= maze.GetLength(0) || col < 0 || col >= maze.GetLength(1))
        return false;

    // 2. Проверка стены или уже посещённой клетки
    if (maze[row, col] == 1 || visited[row, col])
        return false;

    // 3. Проверка, достигли ли мы конечной точки
    if (row == end.row && col == end.col)
        return true;

    // 4. Помечаем текущую клетку как посещённую
    visited[row, col] = true;

    // 5. Рекурсивно пытаемся пройти в каждое из четырёх направлений
    int[] dr = { -1, 1, 0, 0 }; // направления для строк
    int[] dc = { 0, 0, -1, 1 }; // направления для столбцов

    for (int i = 0; i < 4; i++)
    {
        int newRow = row + dr[i];
        int newCol = col + dc[i];

        if (FindShortestPath(maze, newRow, newCol, end, visited))
        {
            return true;
        }
    }

    // 6. Если ни одно направление не привело к цели, возвращаемся назад
    return false;
}