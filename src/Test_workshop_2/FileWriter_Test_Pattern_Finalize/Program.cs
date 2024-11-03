

using FileWriter_Test_Pattern_Finalize;

using (var writer = new FileWriter("example.txt"))
{
    writer.WriteData("Hello, world!");
} //

// Также возможно использовать без using, но с вызовом Dispose вручную:
var writer2 = new FileWriter("example2.txt");
writer2.WriteData("Manual dispose call.");
writer2.Dispose();

// Если Dispose не вызван, Finalize сработает при сборке мусора


Console.ReadLine();