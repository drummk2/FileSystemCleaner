using FileSystemCleaner.Bases;
using System;
using System.IO;

namespace FileSystemCleaner.Cleaners
{
    internal class TempDirectoryCleaner : CleanerBase
    {
        public override void Init(string currentDir, bool isQuiet)
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
