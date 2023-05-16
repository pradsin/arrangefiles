using System;
using System.Collections.Generic;
using System.IO;
using NDesk.Options;

namespace ArrangeFiles
{
    class Program
    {
        public static void Main(string[] args)
        {
            List<string> directories = new List<string>();
            bool showHelp = false;
            string arrangeBy = "MM";

            var p = new OptionSet() {
                { "d|directory=", "the {DIRECTORY} to arrange files.",
                    d => directories.Add (d) },
                { "a|arrange=", "Arrange By could be any of the following\r\n" + "y-> Year, no leading zero (e.g. 2015 would be 15)\r\nyy-> Year, leading zero (e.g. 2015 would be 015)\r\nyyy-> Year, (e.g. 2015)\r\nyyyy-> Year, (e.g. 2015)\r\nM-> Month number(eg.3)\r\nMM-> Month number with leading zero(eg.04)\r\nMMM-> Abbreviated Month Name (e.g. Dec)\r\nMMMM-> Full month name (e.g. December)\r\nd -> Represents the day of the month as a number from 1 through 31. \r\ndd -> Represents the day of the month as a number from 01 through 31.\r\nddd-> Represents the abbreviated name of the day (Mon, Tues, Wed, etc).\r\ndddd-> Represents the full name of the day (Monday, Tuesday, etc).\r\nh-> 12-hour clock hour (e.g. 4).\r\nhh-> 12-hour clock, with a leading 0 (e.g. 06)\r\nH-> 24-hour clock hour (e.g. 15)\r\nHH-> 24-hour clock hour, with a leading 0 (e.g. 22)\r\nm-> Minutes \r\nmm-> Minutes with a leading zero\r\ns-> Seconds\r\nss-> Seconds with leading zero",
                    a => { if (a != null) arrangeBy=a; } },
                { "h|help",  "show this message and exit",
                    v => showHelp = v != null },
            };

            List<string> extra;
            try
            {
                extra = p.Parse(args);
            }
            catch (OptionException e)
            {
                Console.Write("arrange: ");
                Console.WriteLine(e.Message);
                Console.WriteLine("Try `greet --help' for more information.");
                return;
            }

            if (showHelp)
            {
                ShowHelp(p);
                return;
            }


            foreach (string directory in directories)
            {
                FileInfo[] files = FileUtils.GetAllFiles(directory);
                foreach (FileInfo file in files)
                {
                    string folderToMove = FileUtils.GetFolderToMove(file, arrangeBy);
                    if (!Directory.Exists(folderToMove))
                    {
                        Directory.CreateDirectory(folderToMove);
                    }

                    file.MoveTo(Path.Combine(folderToMove, file.Name));
                }
            }
        }

        static void ShowHelp(OptionSet p)
        {
            Console.WriteLine("Usage: arrange [OPTIONS]+ message");
            Console.WriteLine("Greet a list of individuals with an optional message.");
            Console.WriteLine("If no message is specified, a generic greeting is used.");
            Console.WriteLine();
            Console.WriteLine("Options:");
            p.WriteOptionDescriptions(Console.Out);
        }
    }
}