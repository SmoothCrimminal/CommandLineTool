using CommandLineTool.Commands;
using CommandLineTool.Helpers;

while (true)
{
    Console.Write($"<{DirectoryTracker.CurrentFolder}> ${Environment.UserName} ");
    var input = Console.ReadLine()?.Trim();
    if (string.IsNullOrWhiteSpace(input))
        continue;

    if (input == "exit")
        return;
    else if (input.Contains("cd"))
        ChangeDirectoryCommand.Execute(input);
    else if (input == "ls")
        Console.Write(ListSubdirectoriesCommand.Execute());
    else if (input.Contains("mkdir"))
        MakeDirectoryCommand.Execute(input);
    else if (input == "cls")
        Console.Clear();
    else if (input.Contains("delete") || input.Contains("del"))
        DeleteCommand.Execute(input);
    else
        Console.WriteLine("Command not recognized by cmd tool");
}

