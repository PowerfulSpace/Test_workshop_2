
var employees = new[]
{
    new { Id = 1, Name = "Alice", DepartmentId = 101 },
    new { Id = 2, Name = "Bob", DepartmentId = 102 },
    new { Id = 3, Name = "Charlie", DepartmentId = 101 },
    new { Id = 4, Name = "David", DepartmentId = 103 }
};

var departments = new[]
{
    new { DepartmentId = 101, DepartmentName = "HR" },
    new { DepartmentId = 102, DepartmentName = "IT" },
    new { DepartmentId = 103, DepartmentName = "Finance" }
};


var result = employees.Join(
    departments,
    e => e.DepartmentId,
    d => d.DepartmentId,
    (e,d) => new
    {
        Name = e.Name,
        department = d.DepartmentName
    });

var queue = (from e in employees
             join d in departments
             on e.DepartmentId equals d.DepartmentId
             select new
             {
                 Name = e.Name,
                 department = d.DepartmentName
             }).ToArray(); 


foreach (var item in result)
{
    Console.WriteLine(item);
}


Console.ReadLine();



