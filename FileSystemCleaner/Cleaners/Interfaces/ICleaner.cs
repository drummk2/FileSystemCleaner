namespace FileSystemCleaner.Interfaces
{
    /// <summary>
    /// Represents a cleaner that carries out a specific task on theuser's machine, such as finding duplicate files.
    /// </summary>
    internal interface ICleaner
    {
        /// <summary>
        /// Run the cleaner object in question.
        /// </summary>
        /// <param name="currentDir">The current directory in which to execute the cleaner.</param>
        /// <param name="isQuiet">Whether or not the specified cleaner should run quietly.</param>
        void Init(string currentDir = "", bool isQuiet = true);
    }
}