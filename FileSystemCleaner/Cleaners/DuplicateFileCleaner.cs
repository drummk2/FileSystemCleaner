using FileSystemCleaner.Bases;
using System;
using System.Collections.Generic;
using System.IO;

namespace FileSystemCleaner.Cleaners
{
    /// <summary>
    /// A Cleaner class that can remove any duplicate files on a user's file system.
    /// </summary>
    internal class DuplicateFileCleaner : CleanerBase
    {
        /// <summary>
        /// Print to the console and then begin the search for duplicate files.
        /// </summary>
        /// <param name="currentDir">The current directory in which to execute the cleaner.</param>
        /// <param name="isQuiet">The default value for this will be false for security reasons.</param>
        public override void Init(string currentDir, bool isQuiet)
        {
            Console.WriteLine("Deleting duplicate files...");
            Clean(currentDir, isQuiet);
        }

        /// <summary>
        /// Remove all duplicate files from a user's file system
        /// </summary>
        /// <param name="currentDir">The current directory in which to execute the cleaner.</param>
        /// <param name="isQuiet">The default value for this will be false for security reasons.</param>
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