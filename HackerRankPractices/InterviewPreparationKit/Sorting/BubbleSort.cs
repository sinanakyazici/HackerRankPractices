using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;

namespace HackerRankPractices.InterviewPreparationKit.Sorting
{
    public class BubbleSort
    {
        public static void Run()
        {
            var sw = Stopwatch.StartNew();
            countSwaps(new[] { 3, 2, 1 });
            sw.Stop();

            Console.WriteLine($"Elapsed Milliseconds : {sw.ElapsedMilliseconds}");
        }

        static void countSwaps(int[] a)
        {
            var swaps = 0;
            for (int i = 0; i < a.Length; i++)
            {
                var flag = false;
                for (int j = 0; j < a.Length - i - 1; j++)
                {
                    if (a[j] > a[j + 1])
                    {
                        var temp = a[j + 1];
                        a[j + 1] = a[j];
                        a[j] = temp;
                        swaps++;
                        flag = true;
                    }
                }

                if (!flag) break;
            }

            Console.WriteLine($"Array is sorted in {swaps} swaps.");
            Console.WriteLine($"First Element: {a[0]}");
            Console.WriteLine($"Last Element: {a[a.Length - 1]}");
        }
    }
}