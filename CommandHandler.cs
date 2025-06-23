using CommandLineTool.Commands.Abstraction;

namespace CommandLineTool
{
    public class CommandHandler
    {
        private readonly Dictionary<string, ICommand> _commands;
        private readonly Dictionary<string, IAsyncCommand> _asyncCommands;

        public CommandHandler(IEnumerable<ICommand> commands, IEnumerable<IAsyncCommand> asyncCommands)
        {
            _commands = commands.ToDictionary(c => c.Name, StringComparer.OrdinalIgnoreCase);
            _asyncCommands = asyncCommands.ToDictionary(c => c.Name, StringComparer.OrdinalIgnoreCase);
        }

        public async Task RunAsync(string input)
        {
            var parts = input.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length <= 0)
                return;

            var commandName = parts[0];
            var args = parts.Skip(1).ToArray();

            if (_commands.TryGetValue(commandName, out var command))
            {
                command.Execute(args);
            }
            else if (_asyncCommands.TryGetValue(commandName, out var asyncCommand))
            {
                await asyncCommand.ExecuteAsync();
            }
            else
            {
                Console.WriteLine($"Unknown command: {commandName}");
            }
        }
    }
}
