
string input = "abbccc";
HashSet<string> permutations = new HashSet<string>();

GeneratePermutations(input.ToCharArray(), 0, permutations);

Console.WriteLine("Уникальные перестановки строки:");
foreach (string permutation in permutations)
{
    Console.WriteLine(permutation);
}
Console.ReadLine();




void GeneratePermutations(char[] chars, int index, HashSet<string> result)
{
    if (index == chars.Length - 1)
    {
        result.Add(new string(chars));
        return;
    }

    HashSet<char> used = new HashSet<char>();

    for (int i = index; i < chars.Length; i++)
    {
        if (!used.Contains(chars[i]))
        {
            used.Add(chars[i]);
            Swap(chars, index, i);
            GeneratePermutations(chars, index + 1, result);
            Swap(chars, index, i);
        }
    }
}

void Swap(char[] chars, int i, int j)
{
    if (i != j)
    {
        char temp = chars[i];
        chars[i] = chars[j];
        chars[j] = temp;
    }
}