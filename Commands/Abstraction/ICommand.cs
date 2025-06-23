namespace CommandLineTool.Commands.Abstraction
{
    public interface ICommand
    {
        string Name { get; }

        void Execute(string[] args);
    }
}
