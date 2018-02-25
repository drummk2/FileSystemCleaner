using System;

namespace FileSystemCleaner
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Deleting Empty Folders...");
            EmptyDirectoryCleaner.Clean(Environment.CurrentDirectory);
        }
    }
}
