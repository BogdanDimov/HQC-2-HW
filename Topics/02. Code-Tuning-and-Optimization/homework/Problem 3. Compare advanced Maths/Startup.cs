using System;

namespace Problem_3.Compare_advanced_Maths
{
    public class Startup
    {
        public static void Main()
        {
            Console.WriteLine("***Square Root***");
            Sqrt.TestSqrtInt();
            Sqrt.TestSqrtDouble();

            Console.WriteLine("\n***Sinus***");
            Sinus.TestSinInt();
            Sinus.TestSinDouble();

            Console.WriteLine("\n***Natural Logarithm***");
            LogN.TestLogInt();
            LogN.TestLogDouble();
        }
    }
}
