using System;
using System.Diagnostics;

namespace InsertionSortAlgorithmPerformance
{
    public static class InsertionSort
    {
        private static readonly IComparable[] IntArray = { 6, 4, 3, 99, 18, 15, 76, 55, 89 };
        private static readonly IComparable[] DoubleArray = { 6.0d, 4.0d, 3.0d, 99.0d, 18.0d, 15.0d, 76.0d, 55.0d, 89.0d };
        private static readonly IComparable[] StringArray = { "z", "e", "x", "c", "m", "q", "a" };
        private static readonly Stopwatch Sw = new Stopwatch();

        public static void ApplyInsertionSort(IComparable[] array)
        {
            for (var i = 1; i < array.Length; i++)
            {
                var j = i;

                while (j > 0)
                {
                    if (array[j - 1].CompareTo(array[j]) > 0)
                    {
                        var temp = array[j - 1];
                        array[j - 1] = array[j];
                        array[j] = temp;
                        j--;
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }

        public static void Main()
        {
            Sw.Start();
            ApplyInsertionSort(IntArray);
            Sw.Stop();
            Console.WriteLine($"Insertion sort on int: {Sw.Elapsed}");
            Console.WriteLine("Sorted int array: ");
            for (var i = 0; i < IntArray.Length; i++)
            {
                Console.Write(IntArray[i] + " ");
            }

            Console.WriteLine();

            Sw.Reset();
            Sw.Start();
            ApplyInsertionSort(DoubleArray);
            Sw.Stop();
            Console.WriteLine($"\nInsertion sort on double: {Sw.Elapsed}");
            Console.WriteLine("Sorted double array: ");
            for (var i = 0; i < IntArray.Length; i++)
            {
                Console.Write(DoubleArray[i] + " ");
            }

            Console.WriteLine();

            Sw.Reset();
            Sw.Start();
            ApplyInsertionSort(StringArray);
            Sw.Stop();
            Console.WriteLine($"\nInsertion sort on string: {Sw.Elapsed}");
            Console.WriteLine("Sorted string array: ");
            for (var i = 0; i < StringArray.Length; i++)
            {
                Console.Write(StringArray[i] + " ");
            }

            Console.WriteLine();
        }
    }
}