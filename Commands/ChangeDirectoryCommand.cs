using CommandLineTool.Helpers;

namespace CommandLineTool.Commands
{
    public static class ChangeDirectoryCommand
    {
        public static void Execute(string input)
        {
            var parsedInput = ParseInput(input);
            if (!ValidateInput(parsedInput))
                return;

            var combinedPath = Path.Combine(DirectoryTracker.CurrentFolder, string.Join(' ', parsedInput[1..]));

            if (parsedInput[1] == "..")
                DirectoryTracker.GetPreviousFolder();
            else if (!Path.Exists(parsedInput[1]))
            {
                if (Directory.Exists(combinedPath))
                    DirectoryTracker.CurrentFolder = combinedPath;
            }
            else
            {
                if (Directory.Exists(combinedPath))
                    DirectoryTracker.CurrentFolder = combinedPath;
                else
                    DirectoryTracker.CurrentFolder = parsedInput[1];
            }
        }

        private static bool ValidateInput(string[] parsedInput)
        {
            if (parsedInput.Length < 2)
                return ConsoleError("Input was too short");

            if (parsedInput[0] != "cd")
                return ConsoleError("Command not recognized");

            var joinedArgs = string.Join(' ', parsedInput[1..]);
            if (!Path.Exists(joinedArgs))
            {
                if (!Directory.Exists(Path.Combine(DirectoryTracker.CurrentFolder, joinedArgs)))
                    return ConsoleError("Given directory does not exists");
            }

            return true;
        }

        private static string[] ParseInput(string input)
        {
            return input.Split(' ');
        }

        private static bool ConsoleError(string error)
        {
            Console.WriteLine(error);
            return false;
        }
    }
}
