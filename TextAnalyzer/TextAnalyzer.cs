using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAnalyzer
{
    public static class TextAnalyzer
    {
        public static IEnumerable<IGrouping<string, string>> FindMostFrequentTriplets(string text)
        {
            return SplitString(text, 3)
                .AsParallel()
                .Where(triplet => triplet.All(ch => char.IsLetter(ch)))
                .GroupBy(triplet => triplet)
                .OrderByDescending(group => group.Count());
        }

        private static IEnumerable<string> SplitString(string source, int substringLength)
        {
            for (int i = substringLength; i <= source.Length; i++)
                yield return source.Substring(i - substringLength, substringLength);
        }
    }
}
