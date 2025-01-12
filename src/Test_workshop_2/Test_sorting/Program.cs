
var products = new[]
{
    new { Id = 1, Name = "Laptop", Price = 1200, Category = "Electronics" },
    new { Id = 2, Name = "Smartphone", Price = 800, Category = "Electronics" },
    new { Id = 3, Name = "Table", Price = 150, Category = "Furniture" },
    new { Id = 4, Name = "Chair", Price = 100, Category = "Furniture" },
    new { Id = 5, Name = "Headphones", Price = 200, Category = "Electronics" },
    new { Id = 6, Name = "Monitor", Price = 300, Category = "Electronics" },
    new { Id = 7, Name = "Sofa", Price = 700, Category = "Furniture" },
    new { Id = 8, Name = "Keyboard", Price = 50, Category = "Electronics" },
    new { Id = 9, Name = "Mouse", Price = 25, Category = "Electronics" },
    new { Id = 10, Name = "Desk", Price = 400, Category = "Furniture" },
    new { Id = 11, Name = "TV", Price = 600, Category = "Electronics" },
    new { Id = 12, Name = "Wardrobe", Price = 1000, Category = "Furniture" },
    new { Id = 13, Name = "Blender", Price = 150, Category = "Kitchen" },
    new { Id = 14, Name = "Toaster", Price = 80, Category = "Kitchen" },
    new { Id = 15, Name = "Fan", Price = 120, Category = "Electronics" },
    new { Id = 16, Name = "Microwave", Price = 300, Category = "Kitchen" },
    new { Id = 17, Name = "Bookshelf", Price = 250, Category = "Furniture" },
    new { Id = 18, Name = "Oven", Price = 700, Category = "Kitchen" },
    new { Id = 19, Name = "Vacuum Cleaner", Price = 500, Category = "Home Appliances" },
    new { Id = 20, Name = "Refrigerator", Price = 1500, Category = "Home Appliances" }
};


var result = products
    .Where(x => x.Category == "Electronics" && x.Price >= 300)
    .OrderByDescending(p => p.Price)
    .Skip(3)
    .Take(3)
    .Select(x => new { x.Id, x.Name, x.Price, x.Category })
    .ToArray();


Array.ForEach(result, x => Console.WriteLine($"Id: {x.Id}, Name: {x.Name}, Price: {x.Price}, Category: {x.Category}"));




Console.ReadLine();



