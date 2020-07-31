using FileSystemCleaner.Bases;
using FileSystemCleaner.Cleaners;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FileSystemCleaner
{
    /// <summary>
    /// The main program. Runs any cleaners that have been called.
    /// </summary>
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
            string quietFlag = (args.Length > 1) ? args[1].Replace('/', ' ').Trim().ToLower() : string.Empty;
            bool isQuiet = quietFlag.Equals("quiet");

            Dictionary<string, CleanerBase> cleaners = new Dictionary<string, CleanerBase>
            {
                { "duplicate", new DuplicateFileCleaner() },
                { "empty", new EmptyDirectoryCleaner() },
                { "old", new OldFileCleaner() },
                { "temp", new TempDirectoryCleaner() }
            };

            if (action.Equals("all"))
                cleaners.Values.ToList().ForEach(c => c.Init(Environment.CurrentDirectory, isQuiet));
            else
                cleaners[action].Init(Environment.CurrentDirectory, isQuiet);
        }
    }
}
