using FileSystemCleaner.Cleaners;
using FileSystemCleaner.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FileSystemCleaner
{
    /// <summary>
    /// The main program. Runs any cleaners that have been called.
    /// </summary>
    internal class Program
    {
        private static void Main(string[] args)
        {
            if (args.Length <= 0)
            {
                Console.WriteLine("No command line arguments were provided!");
                Environment.Exit(1);
            }

            string action = args[0].Replace("/", string.Empty).Trim().ToLower();
            string quietFlag = args.ElementAtOrDefault(1)?.Replace("/", string.Empty).ToLower() ?? string.Empty;
            bool isQuiet = quietFlag.Equals("quiet");

            Dictionary<string, ICleaner> cleaners = new Dictionary<string, ICleaner>
            {
                { "duplicate", new DuplicateFileCleaner() },
                { "empty", new EmptyDirectoryCleaner() },
                { "old", new OldFileCleaner() },
                { "temp", new TempDirectoryCleaner() }
            };

            if (action.Equals("all"))
                cleaners.Values.ToList().ForEach(c => c.Init(Environment.CurrentDirectory, isQuiet));
            else if (cleaners.ContainsKey(action))
                cleaners[action].Init(Environment.CurrentDirectory, isQuiet);
            else
                Console.WriteLine("Please provide a valid action (/duplicate, /empty, /old, /temp"));
        }
    }
}