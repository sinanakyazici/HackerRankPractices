using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace HackerRankPractices.InterviewPreparationKit.Sorting
{
    public class FraudulentActivityNotifications
    {
        public static void Run()
        {
            var sw = Stopwatch.StartNew();
            var i = activityNotifications(new[] { 1, 2, 3, 4, 4 }, 4);
            var l = (int)Math.Pow(10, 5) * 2;
            var arr = new int[l];
            for (int j = 0; j < arr.Length; j++)
            {
                arr[j] = new Random().Next(1, 200);
            }
            var ii = activityNotifications(arr, 40000);
            sw.Stop();

            Console.WriteLine($"Result : {i}, Elapsed Milliseconds : {sw.ElapsedMilliseconds}");
        }

        static int activityNotifications(int[] expenditure, int d)
        {
            var notifications = 0;
            var count = new int[201];
            var i1 = (int)Math.Floor((d - 1) / 2d);
            var i2 = (int)Math.Ceiling((d - 1) / 2d);
            for (var i = d - 1; i >= 0; i--) count[expenditure[i]]++;
            for (var i = d; i < expenditure.Length; i++)
            {
                var m = FindMedian(count, i1, i2);
                if (expenditure[i] >= m * 2) notifications++;

                count[expenditure[i - d]]--;
                count[expenditure[i]]++;
            }

            return notifications;
        }

        static double FindMedian(int[] count, int i1, int i2)
        {
            var m1 = 0;
            var m2 = 0;
            for (int j = 0, k = 0; k <= i1; k += count[j], j++) m1 = j;
            for (int j = 0, k = 0; k <= i2; k += count[j], j++) m2 = j;

            return (m1 + m2) / 2d;
        }
    }
}
