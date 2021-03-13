using FileSystemCleaner.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;

namespace FileSystemCleaner.Cleaners
{
    /// <summary>
    /// A cleaner that will remove all empty directories from a user's file system.
    /// </summary>
    internal class EmptyDirectoryCleaner : ICleaner
    {
        /// <summary>
        /// The directory from which the search for empty directories begins.
        /// </summary>
        private static string rootDir;

        /// <summary>
        /// Initialise rootDir and then begin searching for duplicate directories.
        /// </summary>
        /// <param name="currentDir">The current directory in which to execute the cleaner.</param>
        /// <param name="isQuiet">Whether or not the specified cleaner should run quietly.</param>
        public void Init(string currentDir, bool isQuiet)
        {
            Console.WriteLine("Deleting empty directories...");
            rootDir = currentDir;
            Clean(currentDir, isQuiet);
        }

        /// <summary>
        /// Remove all empty directories from a user's file system.
        /// </summary>
        /// <param name="currentDir">The current directory in which to execute the cleaner.</param>
        /// <param name="isQuiet">Whether or not the specified cleaner should run quietly.</param>
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