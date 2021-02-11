using FileSystemCleaner.Interfaces;
using System;
using System.IO;

namespace FileSystemCleaner.Cleaners
{
    /// <summary>
    /// A simple cleaner for clearing out a user's TEMP directory.
    /// </summary>
    internal class TempDirectoryCleaner : ICleaner
    {
        /// <summary>
        /// Delete all directories and files within the TEMP directory.
        /// </summary>
        public void Init(string currentDir, bool isQuiet)
        {
            Console.WriteLine("Clearing TEMP directory");
            foreach (string dir in Directory.EnumerateDirectories(Path.GetTempPath()))
            {
                try { Directory.Delete(dir, true); } catch (IOException) { }
            }

            foreach (string file in Directory.EnumerateFiles(Path.GetTempPath()))
            {
                try { File.Delete(file); } catch (IOException) { }
            }
        }
    }
}