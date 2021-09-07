using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAnalyzer
{
    class Analyzer
    {
        private static string _neededFile { get; set; }
        private static Stopwatch _stopwatch { get; set; }
        static void Main(string[] args)
        {
            _stopwatch = new Stopwatch();
            _stopwatch.Start();

            Console.WriteLine("Путь до текстового файла");

            _neededFile = Console.ReadLine();
            TextChecker(_neededFile);

            Console.ReadKey();
        }

        private static void TextChecker(string filePath)
        {
            string text = File.ReadAllText(filePath);

            IEnumerable<IGrouping<string, string>> triplets = LettersAmount(text, 3)
                .Where(x => x.All(ch => char.IsLetter(ch)))
                .GroupBy(txt => txt);

            string finalResult = string.Join(", ", triplets
                .OrderByDescending(gr => gr.Count())
                .Take(10)
                .Select(gr => $"{gr.Key}"));

            Console.Write(finalResult);

            _stopwatch.Stop();
            Console.WriteLine("\n" + _stopwatch.ElapsedMilliseconds);
        }

        public static IEnumerable<string> LettersAmount(string source, int length)
        {
            for (int i = length; i <= source.Length; i++)
                yield return source.Substring(i - length, length);
        }
    }
}
