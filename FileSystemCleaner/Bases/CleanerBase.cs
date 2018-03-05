using System;

namespace FileSystemCleaner.Bases
{
    internal abstract class CleanerBase
    {
        public virtual void Init(string currentDir = "", bool isQuiet = true) { }
    }
}
