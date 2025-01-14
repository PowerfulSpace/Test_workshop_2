
var sales = new[]
{
    new { ProductId = 1, Quantity = 10, Price = 100 },
    new { ProductId = 2, Quantity = 5, Price = 200 },
    new { ProductId = 1, Quantity = 7, Price = 100 },
    new { ProductId = 3, Quantity = 3, Price = 300 },
    new { ProductId = 2, Quantity = 2, Price = 200 },
    new { ProductId = 3, Quantity = 8, Price = 300 }
};

var result = sales
    .GroupBy(x => x.ProductId)
    .Select(x => new
    {
        ProductId = x.Key,
        TotalRevenue = x.Sum(s => s.Quantity * s.Price)
    })
    .OrderByDescending(x => x.TotalRevenue)
    .Take(3);

foreach (var item in result)
{
    Console.WriteLine(item);
}


Console.ReadLine();