using System.Collections.Generic;
using System.IO;

namespace FileSystemCleaner
{
    internal static class EmptyDirectoryCleaner
    {
        internal static void Init(string currentDir, bool isQuiet)
        {
            new List<string>(Directory.GetDirectories(currentDir)).ForEach(dir => Clean(dir, isQuiet));
        }

        private static void Clean(string currentDir, bool isQuiet)
        {
            new List<string>(Directory.GetDirectories(currentDir)).ForEach(dir => Clean(dir, isQuiet));

            if (Directory.GetDirectories(currentDir).Length == 0 && Directory.GetFiles(currentDir).Length == 0)
            {
                if (isQuiet)
                {
                    if (Utilities.GetDeleteConfirmation(currentDir))
                    {
                        Directory.Delete(currentDir);
                    }
                }
                else
                {
                    Directory.Delete(currentDir);
                }
            }
        }
    }
}