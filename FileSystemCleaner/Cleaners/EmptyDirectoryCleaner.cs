using FileSystemCleaner.Interfaces;
using System.Collections.Generic;
using System.IO;

namespace FileSystemCleaner.Cleaners
{
    internal class EmptyDirectoryCleaner : ICleaner
    {
        public void Init(string currentDir, bool isQuiet)
        {
            System.Console.WriteLine(isQuiet);
            new List<string>(Directory.GetDirectories(currentDir)).ForEach(dir => Clean(dir, isQuiet));
        }

        private void Clean(string currentDir, bool isQuiet)
        {
            new List<string>(Directory.GetDirectories(currentDir)).ForEach(dir => Clean(dir, isQuiet));

            if (Directory.GetDirectories(currentDir).Length == 0 && Directory.GetFiles(currentDir).Length == 0)
            {
                if (isQuiet)
                {
                    Directory.Delete(currentDir);
                }
                else
                {
                    if (Utilities.GetDeleteConfirmation(currentDir))
                    {
                        Directory.Delete(currentDir);
                    }
                }
            }
        }
    }
}