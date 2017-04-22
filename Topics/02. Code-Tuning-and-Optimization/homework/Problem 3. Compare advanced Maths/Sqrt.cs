using System;
using System.Diagnostics;

namespace Problem_3.Compare_advanced_Maths
{
    public static class Sqrt
    {
        private static readonly Stopwatch Sw = new Stopwatch();
        private static TimeSpan Elapsed;

        private static TimeSpan MeasurePerformance(dynamic value)
        {
            Sw.Start();
            for (var i = 0; i < 1000000; i++)
            {
                value = Math.Sqrt(value);
            }

            Sw.Stop();
            var time = Sw.Elapsed;
            Sw.Reset();
            return time;
        }

        public static void TestSqrtInt()
        {
            int value = 1000;
            Elapsed = MeasurePerformance(value);
            Console.WriteLine("Int: " + Elapsed);
        }

        public static void TestSqrtDouble()
        {
            double value = 1000;
            Elapsed = MeasurePerformance(value);
            Console.WriteLine("Double: " + Elapsed);
        }
    }
}
