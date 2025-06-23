using CommandLineTool.Commands;

namespace CommandLineTool
{
    public class CommandHandler
    {
        private readonly Dictionary<string, ICommand> _commands;

        public CommandHandler(IEnumerable<ICommand> commands)
        {
            _commands = commands.ToDictionary(c => c.Name, StringComparer.OrdinalIgnoreCase);
        }

        public void Run(string input)
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
            else
            {
                Console.WriteLine($"Unknown command: {commandName}");
            }
        }
    }
}
