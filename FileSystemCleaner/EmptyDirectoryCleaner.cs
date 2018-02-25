using System.Collections.Generic;
using System.IO;

namespace FileSystemCleaner
{
    internal static class EmptyDirectoryCleaner
    {
        internal static void Clean(string currentDir)
        {
            new List<string>(Directory.GetDirectories(currentDir)).ForEach(dir => Clean(dir));
          
            if (Directory.GetDirectories(currentDir).Length == 0 && Directory.GetFiles(currentDir).Length == 0)
                    Directory.Delete(currentDir);
        }
    }
}