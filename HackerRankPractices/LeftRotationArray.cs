using System;
using System.Diagnostics;
using System.Linq;

namespace HackerRankPractices
{
    public class LeftRotationArray
    {
        public static void Run()
        {
            var sw = Stopwatch.StartNew();
            var i = rotLeft(new[] { 1, 2, 3, 4, 5 }, 4);
            sw.Stop();

            Console.WriteLine($"Result : [{string.Join(',', i)}], Elapsed Milliseconds : {sw.ElapsedMilliseconds}");
        }

        static int[] rotLeft(int[] a, int d)
        {
            var n1 = a.Take(d);
            var n2 = a.Skip(d);
            var n3 = n2.Concat(n1);
            return n3.ToArray();
        }
    }
}