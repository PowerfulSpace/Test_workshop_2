
using HtmlAgilityPack;

string url = "https://example.com";


HtmlWeb web = new HtmlWeb();
HtmlDocument doc = web.Load(url);


List<string> links = new List<string>();
foreach (HtmlNode link in doc.DocumentNode.SelectNodes("//a[@href]"))
{
    string hrefValue = link.GetAttributeValue("href", string.Empty);
    if (!string.IsNullOrEmpty(hrefValue))
    {
        links.Add(hrefValue);
    }
}

// Выводим найденные ссылки
Console.WriteLine("Найденные ссылки:");
foreach (string link in links)
{
    Console.WriteLine(link);
}


Console.ReadLine();