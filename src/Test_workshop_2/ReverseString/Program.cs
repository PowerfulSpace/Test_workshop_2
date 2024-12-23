

using System.Text;

string str = "hello";


Console.WriteLine(GetReverseString(str));



Console.ReadLine();



string GetReverseString(string str)
{
    char[] chars = str.ToCharArray();
    Array.Reverse(chars);
    return new string(chars);
}