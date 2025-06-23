using CommandLineTool.Commands.Abstraction;
using CommandLineTool.Helpers;

namespace CommandLineTool.Commands
{
    public class MakeDirectoryCommand : BaseCommand, ICommand
    {
        public string Name => "mkdir";

        public void Execute(string[] args)
        {
            if (!ValidateInput(args))
                return;

            var combinedArgs = string.Join(' ', args);

            try
            {
                Directory.CreateDirectory(Path.Combine(DirectoryTracker.CurrentFolder, combinedArgs));
            }
            catch (Exception e)
            {
                Console.WriteLine("Could not create a directory: {0}", e.Message);
            }
        }

        protected override bool ValidateInput(string[] args, Func<bool>? additionalValidation = null)
        {
            return base.ValidateInput(args, () =>
            {
                var combiedArgs = string.Join(' ', args);

                if (string.IsNullOrWhiteSpace(combiedArgs))
                    return ConsoleError("Cannot create folder with empty name!");

                if (Path.HasExtension(combiedArgs))
                    return ConsoleError("mkdir command is used for creating folders only");

                return true;
            });
        }
    }
}
