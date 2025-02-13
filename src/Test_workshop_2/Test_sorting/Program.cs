



using System.Text.RegularExpressions;

string pattern = @"\b(\w+?)\s\1\b";
string input = "This this is a nice day. What about this? This tastes good. I saw a a dog.";
foreach (Match match in Regex.Matches(input, pattern, RegexOptions.IgnoreCase))
    Console.WriteLine("{0} (duplicates '{1}') at position {2}",
                      match.Value, match.Groups[1].Value, match.Index);


Console.ReadLine();


