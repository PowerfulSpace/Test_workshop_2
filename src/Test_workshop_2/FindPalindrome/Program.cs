
string[] lines =
{
    "A man, a plan, a canal, Panama",
    "Was it a car or a cat I saw?",
    "No lemon, no melon",
    "Hello, world!",
    "Madam, in Eden, I'm Adam",
    "Racecar",
    "Not a palindrome"
};


foreach (string line in lines)
{
    if (IsPalindrome(line))
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Строка \"{line}\" является палиндромом");
        Console.ForegroundColor = ConsoleColor.Gray;
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"\"{line}\" - Не палиндром");
        Console.ForegroundColor = ConsoleColor.Gray;
    }
}


Console.ReadLine();


bool IsPalindrome(string str)
{
    if (string.IsNullOrEmpty(str)) { return true; }

    HashSet<char> chars = new HashSet<char> { ',', '.', '!', ':', ';', ' ', '\'', '?' };

    str = str.ToLower();

    for (int i = 0, j = str.Length - 1; i < j; i++, j--)
    {
        while (i < j && chars.Contains(str[i])) { i++; }
        while (i < j && chars.Contains(str[j])) { j--; }

        if (str[i] != str[j]) { return false; }
    }

    return true;
}


bool IsPalindrome2(string str)
{
    // Удаление пробелов, знаков препинания и перевод в нижний регистр
    str = new string(str
        .Where(char.IsLetterOrDigit) // Оставляем только буквы и цифры
        .ToArray())
        .ToLower();

    // Проверка палиндрома двумя указателями
    for (int i = 0, j = str.Length - 1; i < j; i++, j--)
    {
        if (str[i] != str[j]) return false;
    }

    return true;
}