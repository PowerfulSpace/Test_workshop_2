



var dataService = new DataService();

var data1 = await dataService.GetDataAsync(1);
Console.WriteLine(data1);

var data2 = await dataService.GetDataAsync(1);
Console.WriteLine(data2);



Console.ReadLine();



