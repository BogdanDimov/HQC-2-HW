using System;
using System.Diagnostics;

namespace SelectionSortPerformance
{
    public static class SelectionSort
    {
        private static readonly IComparable[] IntArray = { 6, 4, 3, 99, 18, 15, 76, 55, 89 };
        private static readonly IComparable[] DoubleArray = { 6.0d, 4.0d, 3.0d, 99.0d, 18.0d, 15.0d, 76.0d, 55.0d, 89.0d };
        private static readonly IComparable[] StringArray = { "z", "e", "x", "c", "m", "q", "a" };
        private static readonly Stopwatch Sw = new Stopwatch();

        public static void ApplySelectionSort<T>(T[] arr)
            where T : IComparable
        {
            //pos_min is short for position of min
            int pos_min;
            T temp;

            for (int i = 0; i < arr.Length - 1; i++)
            {
                pos_min = i; //set pos_min to the current index of array

                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j].CompareTo(arr[pos_min]) < 0)
                    {
                        pos_min = j;
                    }
                }

                //if pos_min no longer equals i than a smaller value must have been found, so a swap must occur
                if (pos_min != i)
                {
                    temp = arr[i];
                    arr[i] = arr[pos_min];
                    arr[pos_min] = temp;
                }
            }
        }

        public static void Main()
        {
            Sw.Start();
            ApplySelectionSort(IntArray);
            Sw.Stop();
            Console.WriteLine($"Selection sort on int: {Sw.Elapsed}");
            Console.WriteLine("Sorted int array: ");
            for (var i = 0; i < IntArray.Length; i++)
            {
                Console.Write(IntArray[i] + " ");
            }

            Console.WriteLine();

            Sw.Reset();
            Sw.Start();
            ApplySelectionSort(DoubleArray);
            Sw.Stop();
            Console.WriteLine($"\nSelection sort on double: {Sw.Elapsed}");
            Console.WriteLine("Sorted double array: ");
            for (var i = 0; i < IntArray.Length; i++)
            {
                Console.Write(DoubleArray[i] + " ");
            }

            Console.WriteLine();

            Sw.Reset();
            Sw.Start();
            ApplySelectionSort(StringArray);
            Sw.Stop();
            Console.WriteLine($"\nSelection sort on string: {Sw.Elapsed}");
            Console.WriteLine("Sorted string array: ");
            for (var i = 0; i < StringArray.Length; i++)
            {
                Console.Write(StringArray[i] + " ");
            }

            Console.WriteLine();
        }
    }
}
