using System;

namespace FileSystemCleaner
{
    internal class Utilities
    {
        internal static bool GetDeleteConfirmation(string currentDir)
        {
            Console.Write("Delete " + currentDir + "? <y/n> ");
            return Console.ReadLine().Equals("y", StringComparison.InvariantCultureIgnoreCase);
        }
    }
}
