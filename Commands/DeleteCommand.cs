using CommandLineTool.Commands.Abstraction;
using CommandLineTool.Helpers;

namespace CommandLineTool.Commands
{
    public class DeleteCommand : BaseCommand, ICommand
    {
        public string Name => "del";

        public void Execute(string[] args)
        {
            if (!ValidateInput(args))
                return;

            var combinedArgs = string.Join(' ', args);

            try
            {
                var combinedPath = Path.Combine(DirectoryTracker.CurrentFolder, combinedArgs);
                if (Directory.Exists(combinedPath))
                    Directory.Delete(combinedPath);

                if (File.Exists(combinedPath))
                    File.Delete(combinedPath);
            }
            catch (Exception e)
            {
                Console.WriteLine("Could not remove directory or file: {0}", e.Message);
            }
        }

        protected override bool ValidateInput(string[] args, Func<bool>? additionalValidation = null)
        {
            return base.ValidateInput(args, () =>
            {
                var combiedArgs = string.Join(' ', args);

                var combinedPath = Path.Combine(DirectoryTracker.CurrentFolder, combiedArgs);
                if (!Directory.Exists(combinedPath) && !File.Exists(combinedPath))
                    return ConsoleError("Given directory or file does not exist");

                return true;
            });
        }
    }
}
