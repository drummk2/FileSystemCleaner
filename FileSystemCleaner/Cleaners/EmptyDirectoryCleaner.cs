using FileSystemCleaner.Bases;
using System;
using System.Collections.Generic;
using System.IO;

namespace FileSystemCleaner.Cleaners
{
    internal class EmptyDirectoryCleaner : CleanerBase
    {
        private static string rootDir;

        public override void Init(string currentDir, bool isQuiet)
        {
            Console.WriteLine("Deleting empty directories...");
            rootDir = currentDir;
            Clean(currentDir, isQuiet);
        }

        private void Clean(string currentDir, bool isQuiet)
        {
            new List<string>(Directory.GetDirectories(currentDir)).ForEach(dir => Clean(dir, isQuiet));

            if (Directory.GetDirectories(currentDir).Length == 0 && Directory.GetFiles(currentDir).Length == 0 && !currentDir.Equals(rootDir))
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