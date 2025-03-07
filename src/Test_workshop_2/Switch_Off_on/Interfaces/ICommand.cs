namespace Switch_Off_on.Interfaces
{
    public interface ICommand
    {
        void Execute();
        void Undo();
    }
}
