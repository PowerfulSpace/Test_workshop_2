

using System.Text;

string str = "hello";


Console.WriteLine(GetReverseString1(str));
Console.WriteLine(GetReverseString2(str));
Console.WriteLine(GetReverseString3(str));
Console.WriteLine(GetReverseString4(str));


Console.ReadLine();


string GetReverseString1(string str)
{
    Stack<char> chars = new Stack<char>();
    StringBuilder sb = new StringBuilder();

    foreach (char c in str)
    {
        chars.Push(c);
    }
    foreach (char c in chars)
    {
        sb.Append(c);
    }

    return sb.ToString();
}

string GetReverseString2(string str)
{
    var s = str.Reverse();
    var result = string.Concat(s);

    return result;
}

string GetReverseString3(string str)
{
    char[] chars = str.ToCharArray();
    char temp;

    for (int i = 0,j = str.Length - 1; i < str.Length / 2; i++,j--)
    {
        temp = str[i];
        chars[i] = str[j];
        chars[j] = temp;
    }

    return new string(chars);
}

string GetReverseString4(string str)
{
    char[] chars = str.ToCharArray();
    Array.Reverse(chars);
    return new string(chars);
}