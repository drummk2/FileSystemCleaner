using System;

namespace FileSystemCleaner
{
    internal class Utilities
    {
        internal static bool GetDeleteConfirmation(string currentDir)
        {
            Console.Write("Delete " + currentDir + "? <y/n> ");
            return Console.ReadLine()[0].ToString().Equals("y", StringComparison.InvariantCultureIgnoreCase);
        }
    }
}
