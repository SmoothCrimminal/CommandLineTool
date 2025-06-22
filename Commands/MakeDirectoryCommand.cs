using CommandLineTool.Helpers;

namespace CommandLineTool.Commands
{
    public static class MakeDirectoryCommand
    {
        public static void Execute(string input)
        {
            var parsedInput = ParseInput(input);
            if (!ValidateInput(parsedInput))
                return;

            var combinedArgs = string.Join(' ', parsedInput[1..]);

            try
            {
                Directory.CreateDirectory(Path.Combine(DirectoryTracker.CurrentFolder, combinedArgs));
            }
            catch (Exception e)
            {
                Console.WriteLine("Could not create a directory: {0}", e.Message);
            }
        }

        private static bool ValidateInput(string[] args)
        {
            if (args.Length < 2)
                return ConsoleError("Input was too short");

            if (args[0] != "mkdir")
                return ConsoleError("Command was not recognized!");

            var combiedArgs = string.Join(' ', args[1..]);

            if (string.IsNullOrWhiteSpace(combiedArgs))
                return ConsoleError("Cannot create folder with empty name!");

            if (Path.HasExtension(combiedArgs))
                return ConsoleError("mkdir command is used for creating folders only");

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
