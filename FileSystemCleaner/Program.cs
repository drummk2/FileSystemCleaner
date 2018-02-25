using System;

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

            string action = args[0].Replace('/', ' ').Trim();
            string quietFlag = (args.Length > 1) ? args[1].Replace('/', ' ').Trim() : string.Empty;
            bool isQuiet = quietFlag.Equals("quiet", StringComparison.InvariantCultureIgnoreCase);

            if (action.Equals("empty", StringComparison.InvariantCultureIgnoreCase))
            {
                EmptyDirectoryCleaner.Init(Environment.CurrentDirectory, isQuiet);
            }
        }
    }
}
