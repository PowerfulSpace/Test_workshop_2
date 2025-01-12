

var numbers = new[] { 5, 1, 9, 2, 8, 3, 7 };

var array = numbers.Distinct().OrderBy(x => x).ToArray();

int result = -1;

if(array.Length >= 2)
{
    result = array[array.Length - 2];
}

Console.ReadLine();



