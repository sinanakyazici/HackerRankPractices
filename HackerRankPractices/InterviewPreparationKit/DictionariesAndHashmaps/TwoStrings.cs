using System;
using System.Diagnostics;
using System.Linq;

namespace HackerRankPractices.InterviewPreparationKit.DictionariesAndHashmaps
{
    public class TwoStrings
    {
        public static void Run()
        {
            var sw = Stopwatch.StartNew();
            var i = twoStrings("hello", "world");
            sw.Stop();

            Console.WriteLine($"Result : {i}, Elapsed Milliseconds : {sw.ElapsedMilliseconds}");
        }

        static string twoStrings(string s1, string s2)
        {
            var count = s1.ToCharArray().AsParallel().Intersect(s2.ToCharArray().AsParallel()).Count();
            return count > 0 ? "YES" : "NO";
        }
    }
}