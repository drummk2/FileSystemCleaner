using FileSystemCleaner.Bases;
using System.IO;
using System.Collections.Generic;

namespace FileSystemCleaner.Cleaners
{
    internal class DuplicateFileCleaner : CleanerBase
    {
        public override void Init(string currentDir, bool isQuiet)
        {
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
