using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAnalyzer
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Путь до текстового файла: ");
            var filePath = Console.ReadLine();

            var timer = new Stopwatch();
            timer.Start();

            string text = File.ReadAllText(filePath);

            var mostFrequentTriplets = TextAnalyzer.FindMostFrequentTriplets(text);
            ShowResult(mostFrequentTriplets);

            timer.Stop();
            Console.WriteLine($"Время выполнения: {timer.ElapsedMilliseconds}");

            Console.ReadKey();
        }

        private static void ShowResult(IEnumerable<IGrouping<string, string>> triplets)
        {
            string result = string.Join(", ", triplets
                .Take(10)
                .Select(triplet => $"{triplet.Key}"));

            Console.WriteLine(result);
        }
    }
}
