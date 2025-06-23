using CommandLineTool.Commands.Abstraction;

namespace CommandLineTool.Commands
{
    public class ExitCommand : ICommand
    {
        public string Name => "exit";

        public void Execute(string[] args)
        {
            Environment.Exit(0);
        }
    }
}
