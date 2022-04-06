namespace SortingEnhanced
{
    using System;
    using System.Diagnostics;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var input = GetRandomArray(1_500_000);

            var array = input.ToArray();
            var timer = Stopwatch.StartNew();

            Array.Sort(array, 0, array.Length);
            Console.WriteLine($"Default Sort: {timer.Elapsed}");
            ValidateSorted(array);

            array = input.ToArray();
            timer = Stopwatch.StartNew();

            MergeSort.Sort(array, 0, array.Length - 1);
            Console.WriteLine($"Merge Sort: {timer.Elapsed}");
            ValidateSorted(array);

            array = input.ToArray();
            timer = Stopwatch.StartNew();

            ThreadMergeSort.ParallelSort(array, 0, array.Length - 1);
            Console.WriteLine($"Thread Merge Sort: {timer.Elapsed}");
            ValidateSorted(array);

            array = input.ToArray();
            timer = Stopwatch.StartNew();

            QuickSort.Sort(array, 0, array.Length - 1);
            Console.WriteLine($"Quick Sort: {timer.Elapsed}");
            ValidateSorted(array);

            array = input.ToArray();
            timer = Stopwatch.StartNew();

            ThreadQuickSort.ParallelSort(array, 0, array.Length - 1);
            Console.WriteLine($"Thread Quick Sort: {timer.Elapsed}");
            ValidateSorted(array);

            array = input.ToArray();
            timer = Stopwatch.StartNew();

            var sorted = array.AsParallel().OrderBy(n => n).ToArray();
            Console.WriteLine($"Parallel LINQ: {timer.Elapsed}");
            ValidateSorted(sorted);
        }

        private static int[] GetRandomArray(int count)
            => Enumerable
                .Range(1, count)
                .OrderBy(_ => Guid.NewGuid())
                .ToArray();

        private static void ValidateSorted(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i] > array[i + 1])
                {
                    throw new InvalidOperationException("Array is not sorted!");
                }
            }
        }
    }
}
