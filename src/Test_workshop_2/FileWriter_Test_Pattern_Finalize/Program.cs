

using FileWriter_Test_Pattern_Finalize;

using (var writer = new FileWriter("example.txt"))
{
    writer.WriteData("Hello, world!");
} //
