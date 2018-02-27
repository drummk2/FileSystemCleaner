namespace FileSystemCleaner.Interfaces
{
    internal interface ICleaner
    {
        void Init(string currentDir, bool isQuiet);
    }
}
