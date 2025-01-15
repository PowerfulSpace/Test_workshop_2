
var transactions = new[]
{
    new { ClientId = 1, Category = "Electronics", Amount = 1200 },
    new { ClientId = 1, Category = "Books", Amount = 200 },
    new { ClientId = 2, Category = "Electronics", Amount = 800 },
    new { ClientId = 2, Category = "Books", Amount = 300 },
    new { ClientId = 1, Category = "Electronics", Amount = 1500 },
    new { ClientId = 2, Category = "Clothing", Amount = 400 }
};


var result = transactions
    .GroupBy(x => x.ClientId)
    .Select(x => new
    {
        ClientId = x.Key,
        Category = x
        .GroupBy(x => x.Category)
        .Select(x => new
        {
            CategoryName = x.Key,
            Amount = x.Sum(x => x.Amount)
        })
    });

foreach (var item in result)
{
    Console.WriteLine($"ClientId: {item.ClientId}");
    foreach (var item2 in item.Category)
    {
        Console.WriteLine($"    Category: {item2.CategoryName}, TotalAmount: {item2.Amount}");
    }
}



Console.ReadLine();



