using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SortScores
{
    class Program
    {
        private static void DisplayUsage()
        {
             Console.WriteLine(@"Expected one argument for input file

     SortScores fileName
");
        }

        static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                DisplayUsage();
                return;
            }

            string fileName = args[0];

            if (!File.Exists(fileName))
            {
                Console.WriteLine($"File '{fileName}' not found");
                return;
            }

            string[] lines;

            try
            {
                lines = File.ReadAllLines(fileName);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unable to read File '{fileName}' : {ex.Message}");
                return;

            }

            List<TestResult> results = new List<TestResult>();

            int errors = 0;

            foreach (var line in lines)
            {
                string text = line.Trim();

                if (string.IsNullOrEmpty(text))
                    continue; // ignore blank lines

                var result = TestResult.FromString(text);

                if (result == null)
                {
                    Console.WriteLine($"Unable to parse line: '{line}'");
                    errors++;
                    continue;
                }

                results.Add(result);
            }

            var outputName = Path.GetFileNameWithoutExtension(fileName) + "-graded.txt";

            try
            {
                using (TextWriter tw = new StreamWriter(outputName))
                {
                    foreach (var result in results
                        .OrderByDescending(tr=>tr.Score)
                        .ThenBy(tr=>tr.LastName)
                        .ThenBy(tr=>tr.FirstName))
                    {
                        string line = $"{result.LastName}, {result.FirstName}, {result.Score}";
                        Console.WriteLine(line);
                        tw.WriteLine(line);
                    }
                }

                if (errors > 0)
                    Console.WriteLine($"Encountered {errors} errors");

                Console.WriteLine($"Finished: created {outputName}");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unable to write to output file '{fileName}' : {ex.Message}");
            }
        }
    }
}
