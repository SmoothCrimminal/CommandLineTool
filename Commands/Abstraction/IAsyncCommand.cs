namespace CommandLineTool.Commands.Abstraction
{
    public interface IAsyncCommand
    {
        string Name { get; }
        Task ExecuteAsync();
    }
}
