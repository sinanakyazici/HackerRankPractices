using System;
using System.Diagnostics;
using System.Linq;

namespace HackerRankPractices
{
    public class MinimumSwaps2
    {
        public static void Run()
        {
            var sw = Stopwatch.StartNew();
            var i = minimumSwaps(new[] { 1,3,5,2,4,6,7 });
            sw.Stop();

            Console.WriteLine($"Result : {i}, Elapsed Milliseconds : {sw.ElapsedMilliseconds}");
        }

        static int minimumSwaps(int[] arr)
        {
            var ordered = arr.Select((x, index) => new[] { index, x }).OrderBy(x => x[1]).ToArray();

            int i = 0;
            int count = 0;
            while (i < arr.Length)
            {
                if (ordered[i][0] == i)
                {
                    i++;
                    continue;
                }

                swap(ordered, i, ordered[i][0]);
                count++;
            }

            return count;
        }

        static void swap(int[][] arr, int i, int j)
        {
            var temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
    }
}
