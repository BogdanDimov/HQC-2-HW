using System;
using System.Diagnostics;

namespace Problem2.Compare_simple_Maths
{
    public static class Increment
    {
        private const int Times = 1000000;
        private static readonly Stopwatch Sw = new Stopwatch();
        private static TimeSpan Elapsed;

        private static TimeSpan GetIncrementationTime(dynamic num)
        {
            Sw.Start();
            for (var i = 0; i < Times; i++)
            {
                num++;
            }

            Sw.Stop();
            var time = Sw.Elapsed;
            Sw.Reset();

            return time;
        }

        public static void TestIncrementInt()
        {
            int number = 0;
            Elapsed = GetIncrementationTime(number);
            Console.WriteLine("Int: " + Elapsed);
        }

        public static void TestIncrementDouble()
        {
            double number = 0;
            Elapsed = GetIncrementationTime(number);
            Console.WriteLine("Double: " + Elapsed);
        }

        public static void TestIncrementLong()
        {
            long number = 0;
            Elapsed = GetIncrementationTime(number);
            Console.WriteLine("Long: " + Elapsed);
        }

        public static void TestIncrementDecimal()
        {
            decimal number = 0;
            Elapsed = GetIncrementationTime(number);
            Console.WriteLine("Decimal: " + Elapsed);
        }

        public static void TestIncrementFloat()
        {
            float number = 0;
            Elapsed = GetIncrementationTime(number);
            Console.WriteLine("Float: " + Elapsed);
        }
    }
}
