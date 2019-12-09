using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace HackerRankPractices.InterviewPreparationKit.Arrays
{
    public class HourglassTwoDimArray
    {
        public static void Run()
        {
            int[][] jaggedArray2 = {
                new[] { 1, 1, 1, 0, 0, 0 },
                new[] { 0, 1, 0, 0, 0, 0 },
                new[] { 1, 1, 1, 0, 0, 0 },
                new[] { 0, 0, 2, 4, 4, 0 },
                new[] { 0, 0, 0, 2, 0, 0 },
                new[] { 0, 0, 1, 2, 4, 0 },
            };

            var sw = Stopwatch.StartNew();
            var i = hourglassSum(jaggedArray2);
            sw.Stop();

            Console.WriteLine($"Result : {i}, Elapsed Milliseconds : {sw.ElapsedMilliseconds}");
        }
        static int hourglassSum(int[][] arr)
        {
            var list = new List<int>();
            for (int y = 0; y < arr.Length - 2; y++)
            {
                for (int x = 0; x < arr[y].Length - 2; x++)
                {
                    var s = Sum(arr, y, x);
                    list.Add(s);
                }
            }

            return list.Max();
        }

        static int Sum(int[][] arr, int y, int x)
        {

            var a1 = arr[y][x];
            var a2 = arr[y][x + 1];
            var a3 = arr[y][x + 2];
            var a4 = arr[y + 1][x + 1];
            var a5 = arr[y + 2][x];
            var a6 = arr[y + 2][x + 1];
            var a7 = arr[y + 2][x + 2];

            return a1 + a2 + a3 + a4 + a5 + a6 + a7;
        }

    }
}