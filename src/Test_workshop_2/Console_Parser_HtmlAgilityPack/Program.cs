


// URL сайта, который будем парсить
string url = "https://example.com";

// Загружаем HTML-документ
HtmlWeb web = new HtmlWeb();
HtmlDocument doc = web.Load(url);

// Извлекаем все ссылки (теги <a>)
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


