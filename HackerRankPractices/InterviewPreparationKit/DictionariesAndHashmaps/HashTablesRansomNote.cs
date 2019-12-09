using System;
using System.Diagnostics;
using System.Linq;

namespace HackerRankPractices.InterviewPreparationKit.DictionariesAndHashmaps
{
    public class HashTablesRansomNote
    {
        public static void Run()
        {
            var sw = Stopwatch.StartNew();
            var i = checkMagazine(new[] { "give", "me", "one", "grand", "today", "night" }, new[] { "give", "one", "grand", "today", "grand" });
            sw.Stop();

            Console.WriteLine($"Result : {i}, Elapsed Milliseconds : {sw.ElapsedMilliseconds}");
        }

        private static string checkMagazine(string[] magazine, string[] note)
        {
            var m = magazine.AsParallel().GroupBy(x => x).Select(x => new { Item = x.Key, Count = x.Count() }).ToList();
            var n = note.AsParallel().GroupBy(x => x).Select(x => new { Item = x.Key, Count = x.Count() }).ToList();
            var k = n.AsParallel().Join(m.AsParallel(), x => x.Item, y => y.Item, (x, y) => new { x.Item, NCount = x.Count, MCount = y.Count }).ToList();
            if (k.Count != n.Count) return "No";
            if (k.Any(x => x.NCount > x.MCount)) return "No";

            return "Yes";
        }
    }
}