using CommandLineTool.Commands.Abstraction;
using CommandLineTool.Helpers;
using System.Text;

namespace CommandLineTool.Commands
{
    public class ListSubdirectoriesCommand : ICommand
    {
        public string Name => "ls";

        public void Execute(string[] args)
        {
            var sb = new StringBuilder();
            var files = Directory.GetFiles(DirectoryTracker.CurrentFolder);
            var subDirs = Directory.GetDirectories(DirectoryTracker.CurrentFolder);

            var allFiles = new List<string>();
            allFiles.AddRange(files);
            allFiles.AddRange(subDirs);

            foreach (var file in allFiles)
                sb.AppendLine(file.Split('\\', StringSplitOptions.RemoveEmptyEntries)[^1]);

            Console.Write(sb.ToString());
        }
    }
}
