namespace CommandLineTool.Commands
{
    public abstract class BaseCommand
    {
        protected virtual bool ValidateInput(string[] args, Func<bool>? additionalValidation = null)
        {
            if (args.Length < 1)
                return ConsoleError("Input was too short");

            var argsCombined = string.Join(' ', args);
            if (string.IsNullOrWhiteSpace(argsCombined))
                return ConsoleError("No args were provided");

            return additionalValidation?.Invoke() ?? true;
        }

        protected bool ConsoleError(string error)
        {
            Console.WriteLine(error);
            return false;
        }
    }
}
