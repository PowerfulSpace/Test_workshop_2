
CountdownEvent countdown = new CountdownEvent(10);

for (int i = 0; i < 10; i++)
{
    Task.Run(() => DoWork(i));
}




Console.ReadLine();

