using CommandLineTool.Helpers;

namespace CommandLineTool.Commands
{
    public static class DeleteCommand
    {
        public static void Execute(string input)
        {
            var parsedInput = ParseInput(input);
            if (!ValidateInput(parsedInput))
                return;

            var combinedArgs = string.Join(' ', parsedInput[1..]);

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

        private static bool ValidateInput(string[] args)
        {
            if (args.Length < 2)
                return ConsoleError("Input was too short");

            if (args[0] != "del" && args[0] != "delete")
                return ConsoleError("Command was not recognized");

            var combiedArgs = string.Join(' ', args[1..]);

            if (string.IsNullOrWhiteSpace(combiedArgs))
                return ConsoleError("Cannot create folder with empty name!");

            var combinedPath = Path.Combine(DirectoryTracker.CurrentFolder, combiedArgs);
            if (!Directory.Exists(combinedPath) && !File.Exists(combinedPath))
                return ConsoleError("Given directory or file does not exist");

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
