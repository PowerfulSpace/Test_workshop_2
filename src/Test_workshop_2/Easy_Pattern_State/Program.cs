﻿

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
public class Context
{
    private IState _state;

    public Context(IState state)
    {
        TransitionTo(state);
    }

    public void TransitionTo(IState state)
    {
        Console.WriteLine($"Context: Transition to {state.GetType().Name}.");
        _state = state;
    }

    public void Request()
    {
        _state.Handle(this);
    }
}