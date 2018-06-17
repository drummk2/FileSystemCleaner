using FileSystemCleaner.Bases;
using System;
using System.Collections.Generic;
using System.IO;

namespace FileSystemCleaner.Cleaners
{
    internal class OldFileCleaner : CleanerBase
    {
        public override void Init(string currentDir, bool isQuiet)
        {
            Console.WriteLine("Deleting old files");
            Clean(currentDir, isQuiet);
        }

        private void Clean(string currentDir, bool isQuiet)
        {
            new List<string>(Directory.GetDirectories(currentDir)).ForEach(dir => Clean(dir, isQuiet));

            new List<string>(Directory.EnumerateFiles(currentDir)).ForEach(file => {
                if (DateTime.Now - File.GetLastWriteTime(file) > TimeSpan.FromDays(1))
                {
                    if (isQuiet)
                    {
                        try
                        {
                            File.Delete(file);
                        }
                        catch (IOException) { }
                    }
                    else
                    {
                        if (Utilities.GetDeleteConfirmation(file))
                        {
                            try
                            {
                                File.Delete(file);
                            }
                            catch (IOException) { }
                        }
                    }
                }
            });
        }
    }
}