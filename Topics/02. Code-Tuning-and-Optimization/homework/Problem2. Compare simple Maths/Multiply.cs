using System;
using System.Diagnostics;

namespace Problem2.Compare_simple_Maths
{
    public static class Multiply
    {
        private const int Times = 1000000;
        private static readonly Stopwatch Sw = new Stopwatch();
        private static TimeSpan Elapsed;

        private static TimeSpan GetMultiplicationTime(dynamic a, dynamic b)
        {
            Sw.Start();
            for (var i = 0; i < Times; i++)
            {
                var c = a * b;
            }

            Sw.Stop();
            var time = Sw.Elapsed;
            Sw.Reset();

            return time;
        }

        public static void TestMultiplyInt()
        {
            int a = 1;
            int b = 2;
            Elapsed = GetMultiplicationTime(a, b);
            Console.WriteLine("Int: " + Elapsed);
        }

        public static void TestMultiplyDouble()
        {
            double a = 1;
            double b = 2;
            Elapsed = GetMultiplicationTime(a, b);
            Console.WriteLine("Double: " + Elapsed);
        }

        public static void TestMultiplyLong()
        {
            long a = 1;
            long b = 2;
            Elapsed = GetMultiplicationTime(a, b);
            Console.WriteLine("Long: " + Elapsed);
        }

        public static void TestMultiplyDecimal()
        {
            decimal a = 1;
            decimal b = 2;
            Elapsed = GetMultiplicationTime(a, b);
            Console.WriteLine("Decimal: " + Elapsed);
        }

        public static void TestMultiplyFloat()
        {
            float a = 1;
            float b = 2;
            Elapsed = GetMultiplicationTime(a, b);
            Console.WriteLine("Float: " + Elapsed);
        }
    }
}
