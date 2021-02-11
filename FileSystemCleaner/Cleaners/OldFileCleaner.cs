using FileSystemCleaner.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;

namespace FileSystemCleaner.Cleaners
{
    /// <summary>
    /// A Cleaner class for deleting old files off of a user's file system.
    /// </summary>
    internal class OldFileCleaner : ICleaner
    {
        /// <summary>
        /// Print to the console and then begin the search for old files.
        /// </summary>
        /// <param name="currentDir">The current directory in which to execute the cleaner.</param>
        /// <param name="isQuiet">Whether or not the specified cleaner should run quietly.</param>
        public void Init(string currentDir, bool isQuiet)
        {
            Console.WriteLine("Deleting old files");
            Clean(currentDir, isQuiet);
        }

        /// <summary>
        /// Remove all files on a user's computer system that have not been written to in a specified timeframe.
        /// </summary>
        /// <param name="currentDir">The current directory in which to execute the cleaner.</param>
        /// <param name="isQuiet">Whether or not the specified cleaner should run quietly.</param>
        private void Clean(string currentDir, bool isQuiet)
        {
            new List<string>(Directory.GetDirectories(currentDir)).ForEach(dir => Clean(dir, isQuiet));
            
            new List<string>(Directory.EnumerateFiles(currentDir)).ForEach(file => {
                if (DateTime.Now - File.GetLastWriteTime(file) > TimeSpan.FromDays(double.Parse(ConfigurationManager.AppSettings["fileLifespanInDays"])))
                {
                    if (isQuiet)
                    {
                        try { File.Delete(file); } catch (IOException) { }
                    }
                    else
                    {
                        if (Utilities.GetDeleteConfirmation(file))
                        {
                            try { File.Delete(file); } catch (IOException) { }
                        }
                    }
                }
            });
        }
    }
}