using FileSystemCleaner.Bases;
using System.IO;

namespace FileSystemCleaner.Cleaners
{
    internal class TempDirectoryCleaner : CleanerBase
    {
        public override void Init(string currentDir, bool isQuiet)
        {
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
