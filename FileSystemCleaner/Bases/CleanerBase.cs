using System;

namespace FileSystemCleaner.Bases
{
    /// <summary>
    /// A base class to represent different types of Cleaner objects.
    /// </summary>
    internal abstract class CleanerBase
    {
        /// <summary>
        /// Run the cleaner object that is extending this class.
        /// </summary>
        /// <param name="currentDir">The current directory in which to execute the cleaner.</param>
        /// <param name="isQuiet">Whether or not the specified cleaner should run quietly.</param>
        public virtual void Init(string currentDir = "", bool isQuiet = true) { }
    }
}
