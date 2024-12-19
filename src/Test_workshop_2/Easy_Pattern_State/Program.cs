

var context = new Context(new ConcreteStateA());

Console.ReadLine();
context.Request();

Console.ReadLine();
context.Request();

Console.ReadLine();
context.Request();


Console.ReadLine();


public interface IState
{
    void Handle(Context context);
}

