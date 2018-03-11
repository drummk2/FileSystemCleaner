using FileSystemCleaner.Bases;
using System;
using System.Collections.Generic;
using System.IO;

namespace FileSystemCleaner.Cleaners
{
    internal class DuplicateFileCleaner : CleanerBase
    {
        public override void Init(string currentDir, bool isQuiet)
        {
            Console.WriteLine("Deleting duplicate files...");
            Clean(currentDir, isQuiet);
        }

        private void Clean(string currentDir, bool isQuiet)
        {
            new List<string>(Directory.GetDirectories(currentDir)).ForEach(dir => Clean(dir, isQuiet));
            
            foreach (string file in Directory.GetFiles(currentDir))
            {
                string path = Path.GetFileNameWithoutExtension(file);

                if (path.Trim().EndsWith(")") || path.Trim().ToLower().EndsWith("copy"))
                {
                    if (Utilities.GetDeleteConfirmation(file))
                    {
                        File.Delete(file);
                    }
                }
            }
        }
    }
}
