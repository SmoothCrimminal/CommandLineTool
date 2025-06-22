using System.Reflection;

namespace CommandLineTool.Helpers
{
    public static class DirectoryTracker
    {
        public static string CurrentFolder { get; set; } = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        public static string ChangeFolder(string path) => CurrentFolder = path;

        public static void GetPreviousFolder() 
        {
            var currentFolderSplit = CurrentFolder.Split('\\', StringSplitOptions.RemoveEmptyEntries);
            if (currentFolderSplit.Length != 1)
                CurrentFolder = string.Join('\\', currentFolderSplit[0..^1]);
        }
    }
}
