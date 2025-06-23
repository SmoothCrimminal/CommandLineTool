using CommandLineTool.Commands.Abstraction;

namespace CommandLineTool.Commands
{
    public class ClearScreenCommand : ICommand
    {
        public string Name => "cls";

        public void Execute(string[] args)
        {
            Console.Clear();
        }
    }
}
