using System;
using System.Diagnostics;

namespace HackerRankPractices
{
    public class ArrayManipulation
    {
        public static void Run()
        {
            var n = GenerateArray(out var arr);
            var sw = Stopwatch.StartNew();
            var i = arrayManipulation(n, arr);
            sw.Stop();

            Console.WriteLine($"Result : {i}, Elapsed Milliseconds : {sw.ElapsedMilliseconds}");
        }

        private static int GenerateArray(out int[][] arr)
        {
            var n = 10000000;
            var m = 200000;
            var r = new Random();
            arr = new int[m][];
            for (int j = 0; j < arr.Length; j++)
            {
                var a = r.Next(1, n);
                var b = r.Next(a, n);
                var k = r.Next(0, 1000000000);
                arr[j] = new[] { a, b, k };
            }

            return n;
        }

        static long arrayManipulation(int n, int[][] queries)
        {
            var arr = new long[n + 1];
            for (var i = 0; i < queries.Length; i++)
            {
                var a = queries[i][0];
                var b = queries[i][1];
                var k = queries[i][2];
                arr[a - 1] += k;
                arr[b] -= k;
            }


            long max = 0;
            long sum = 0;
            for (int i = 0; i <= n; i++)
            {
                sum += arr[i];
                if (sum > max) max = sum;
            }

            return max;
        }

    }
}