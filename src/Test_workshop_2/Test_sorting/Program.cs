
string input = "abc";
HashSet<string> permutations = new HashSet<string>();

GeneratePermutations(input.ToCharArray(), 0, input.Length - 1, permutations);

Console.WriteLine("Уникальные перестановки строки:");
foreach (string permutation in permutations)
{
    Console.WriteLine(permutation);
}
Console.ReadLine();

void GeneratePermutations(char[] chars, int left, int right, HashSet<string> result)
{
    if (left == right)
    {
        result.Add(new string(chars));
        return;
    }

    HashSet<char> used = new HashSet<char>(); // Сбрасывается на каждом уровне

    for (int i = left; i <= right; i++)
    {
        if (!used.Contains(chars[i])) // Проверяем, был ли символ уже использован
        {
            used.Add(chars[i]);
            Swap(chars, left, i);
            GeneratePermutations(chars, left + 1, right, result);
            Swap(chars, left, i); // Возвращаем к исходному состоянию
        }
    }
}

void Swap(char[] chars, int i, int j)
{
    if (i != j) // Убираем бессмысленный свап
    {
        char temp = chars[i];
        chars[i] = chars[j];
        chars[j] = temp;
    }
}