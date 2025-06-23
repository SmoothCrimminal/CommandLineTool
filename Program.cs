using CommandLineTool;
using CommandLineTool.Api;
using CommandLineTool.Commands;
using CommandLineTool.Commands.Abstraction;
using CommandLineTool.Helpers;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();

services.AddHttpClient(nameof(JokeApiService), baseClient => baseClient.BaseAddress = new Uri("https://official-joke-api.appspot.com"));

services.AddSingleton<CommandHandler>();
services.AddSingleton<JokeApiService>();

services.AddSingleton<ICommand, ChangeDirectoryCommand>();
services.AddSingleton<ICommand, DeleteCommand>();
services.AddSingleton<ICommand, ListSubdirectoriesCommand>();
services.AddSingleton<ICommand, MakeDirectoryCommand>();
services.AddSingleton<ICommand, ExitCommand>();
services.AddSingleton<ICommand, EchoCommand>();
services.AddSingleton<ICommand, ClearScreenCommand>();
services.AddSingleton<IAsyncCommand, JokeCommand>();

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

    await commandHandler.RunAsync(input);
}

