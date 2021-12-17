namespace CommandPattern.Commands
{
    public interface ICommand
    {
        void Do();
        bool CanDo();
        void Undo();
    }
}