
var orders = new[]
{
    new { OrderId = 1, ClientId = 1, Amount = 500 },
    new { OrderId = 2, ClientId = 2, Amount = 1500 },
    new { OrderId = 3, ClientId = 1, Amount = 2000 },
    new { OrderId = 4, ClientId = 3, Amount = 800 }
};

var clients = new[]
{
    new { ClientId = 1, Name = "Company A" },
    new { ClientId = 2, Name = "Company B" },
    new { ClientId = 3, Name = "Company C" }
};



var result = orders
    .Where(x => x.Amount > 1000)
    .Join(clients, o => o.ClientId, c => c.ClientId, (o, c) => new
    {
        OrderId = o.OrderId,
        Name = c.Name,
        Amount = o.Amount
    })
    .OrderByDescending(x => x.Amount);

foreach (var item in result)
{
    Console.WriteLine($"Client: {item.Name}, Orders: [OrderId: {item.OrderId}, Amount: {item.Amount}]");
}
Console.ReadLine();

