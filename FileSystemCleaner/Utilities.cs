using System;

namespace FileSystemCleaner
{
    /// <summary>
    /// Contains any necessary utility functions.
    /// </summary>
    internal class Utilities
    {
        /// <summary>
        /// Get confirmation from a user as to whether a file or directory should be deleted.
        /// </summary>
        /// <param name="fileOrDirName">The name of the file/directory that is being deleted.</param>
        /// <returns>Whether or not the user has confirmed the deletion.</returns>
        internal static bool GetDeleteConfirmation(string fileOrDirName)
        {
            Console.Write($"Delete {fileOrDirName} + ? <y/n> ");
            return Console.ReadLine()[0].ToString().Equals("y", StringComparison.InvariantCultureIgnoreCase);
        }
    }
}