using CommandLineTool.Helpers;

namespace CommandLineTool.Commands
{
    public class ChangeDirectoryCommand : BaseCommand, ICommand
    {
        public string Name => "cd";

        public void Execute(string[] args)
        {
            if (!ValidateInput(args))
                return;

            var combinedPath = Path.Combine(DirectoryTracker.CurrentFolder, string.Join(' ', args));

            if (args[0] == "..")
                DirectoryTracker.GetPreviousFolder();
            else if (!Path.Exists(args[0]))
            {
                if (Directory.Exists(combinedPath))
                    DirectoryTracker.CurrentFolder = combinedPath;
            }
            else
            {
                if (Directory.Exists(combinedPath))
                    DirectoryTracker.CurrentFolder = combinedPath;
                else
                    DirectoryTracker.CurrentFolder = args[0];
            }
        }

        protected override bool ValidateInput(string[] args, Func<bool>? additionalValidation = null)
        {
            var joinedArgs = string.Join(' ', args);

            return base.ValidateInput(args, () =>
            {
                if (!Path.Exists(joinedArgs))
                {
                    if (!Directory.Exists(Path.Combine(DirectoryTracker.CurrentFolder, joinedArgs)))
                        return ConsoleError("Given directory does not exists");
                }

                return true;
            });
        }
    }
}
