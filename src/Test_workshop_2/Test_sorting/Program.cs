

var numbers = new[] { 1, 2, 3, 4, 5, 6 };
int targetSum = 7;

var result = numbers
    .SelectMany((x, i) => numbers.Skip(i + 1), (x, y) => new { x, y })
    .Where(pair => pair.x + pair.y == targetSum)
    .Select(pair => (pair.x, pair.y))
    .ToList();

//var pairs = numbers
//         .SelectMany((x, i) => numbers
//             .Skip(i + 1)
//             .Where(y => x + y == targetSum)
//             .Select(y => (x, y))
//         )
//         .ToList();

Console.ReadLine();


