using FileSystemCleaner.Cleaners;
using FileSystemCleaner.Interfaces;
using System;
using System.Collections.Generic;

namespace FileSystemCleaner
{
    public class Program
    {
        public static void Main(string[] args)
        {
            if (args.Length <= 0)
            {
                Console.WriteLine("No command line arguments were provided!");
                Environment.Exit(1);
            }

            string action = args[0].Replace('/', ' ').Trim().ToLower();
            string quietFlag = (args.Length > 1) ? args[1].Replace('/', ' ').Trim() : string.Empty;
            bool isQuiet = quietFlag.Equals("quiet", StringComparison.InvariantCultureIgnoreCase);

            Dictionary<string, ICleaner> cleaners = new Dictionary<string, ICleaner>
            {
                { "empty", new EmptyDirectoryCleaner() },
                { "old", new OldFileCleaner() },
                { "temp", new TempDirectoryCleaner() }
            };

            if (action.Equals("all"))
            {
                foreach (ICleaner cleaner in cleaners.Values)
                {
                    cleaner.Init(Environment.CurrentDirectory, isQuiet);
                }
            }
            else
            {
                cleaners[action].Init(Environment.CurrentDirectory, isQuiet);
            }
        }
    }
}
