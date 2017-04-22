using System;
using System.Diagnostics;

namespace Problem4._Compare_sort__lgorithms
{
    public class QuicksortAlgorithmPerformance
    {
        public static void Main()
        {
            // Create an unsorted array of string elements
            string[] unsortedString = { "z", "e", "x", "c", "m", "q", "a" };
            // Sort the array
            var sw = new Stopwatch();
            sw.Start();
            ApplyQuicksort(unsortedString, 0, unsortedString.Length - 1);
            sw.Stop();
            // Print the sorted array
            for (var i = 0; i < unsortedString.Length; i++)
            {
                Console.Write(unsortedString[i] + " ");
            }

            Console.WriteLine($"\nQuicksort on string: {sw.Elapsed}");

            sw.Reset();
            IComparable[] unsortedInt = { 6, 4, 3, 99, 18, 15, 76, 55, 89 };
            sw.Start();
            ApplyQuicksort(unsortedInt, 0, unsortedInt.Length - 1);
            for (var i = 0; i < unsortedInt.Length; i++)
            {
                Console.Write(unsortedInt[i] + " ");
            }
            sw.Stop();
            Console.WriteLine($"\nQuicksort on int: {sw.Elapsed}");

            sw.Reset();
            IComparable[] unsortedDouble = { 6.0d, 4.0d, 3.0d, 99.0d, 18.0d, 15.0d, 76.0d, 55.0d, 89.0d };
            sw.Start();
            ApplyQuicksort(unsortedDouble, 0, unsortedDouble.Length - 1);
            for (var i = 0; i < unsortedDouble.Length; i++)
            {
                Console.Write(unsortedInt[i] + " ");
            }
            sw.Stop();
            Console.WriteLine($"\nQuicksort on double: {sw.Elapsed}");
        }

        public static void ApplyQuicksort(IComparable[] elements, int left, int right)
        {
            int i = left, j = right;
            var pivot = elements[(left + right) / 2];

            while (i <= j)
            {
                while (elements[i].CompareTo(pivot) < 0)
                {
                    i++;
                }

                while (elements[j].CompareTo(pivot) > 0)
                {
                    j--;
                }

                if (i <= j)
                {
                    // Swap
                    var tmp = elements[i];
                    elements[i] = elements[j];
                    elements[j] = tmp;

                    i++;
                    j--;
                }
            }

            // Recursive calls
            if (left < j)
            {
                ApplyQuicksort(elements, left, j);
            }

            if (i < right)
            {
                ApplyQuicksort(elements, i, right);
            }
        }
    }
}