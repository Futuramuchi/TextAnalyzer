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
            var timer = new Stopwatch();
            timer.Start();

            Console.WriteLine("Путь до текстового файла: ");

            var filePath = Console.ReadLine();
            string text = File.ReadAllText(filePath);

            var mostFriquentTriplets = TextAnalyzer.FindMostFriquentTriplets(text);

            ShowResult(mostFriquentTriplets);
            
            timer.Stop();
            Console.WriteLine($"Время выполнения: {timer.Elapsed}");

            Console.ReadKey();
        }

        private static void ShowResult(IEnumerable<IGrouping<string, string>> triplets)
        {
            string result = string.Join(", ", triplets
                .Take(10)
                .Select(triplet => $"{triplet.Key} {triplet.Count()}"));

            Console.WriteLine(result);
        }
    }
}
