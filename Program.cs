using CommandLineTool;
using CommandLineTool.Commands;
using CommandLineTool.Helpers;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();

services.AddSingleton<CommandHandler>();

services.AddSingleton<ICommand, ChangeDirectoryCommand>();
services.AddSingleton<ICommand, DeleteCommand>();
services.AddSingleton<ICommand, ListSubdirectoriesCommand>();
services.AddSingleton<ICommand, MakeDirectoryCommand>();
services.AddSingleton<ICommand, ExitCommand>();
services.AddSingleton<ICommand, EchoCommand>();
services.AddSingleton<ICommand, ClearScreenCommand>();

var serviceProvider = services.BuildServiceProvider();
var commandHandler = serviceProvider.GetRequiredService<CommandHandler>();

while (true)
{
    Console.Write($"<{DirectoryTracker.CurrentFolder}> ${Environment.UserName} ");

    var input = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(input))
    {
        Console.WriteLine("Input cannot be empty");
        continue;
    }

    commandHandler.Run(input);
}

