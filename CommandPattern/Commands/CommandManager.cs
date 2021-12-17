using System.Collections.Generic;

namespace CommandPattern.Commands
{
    public class CommandManager
    {
        private Stack<ICommand> commands = new Stack<ICommand>();

        public void Invoke(ICommand command)
        {
            if (!command.CanDo()) return;
            commands.Push(command);
            command.Do();
        }

        public void Undo()
        {
            for (; commands.Count > 0; )
            {
                commands.Pop().Undo();
            }
        }
    }
}