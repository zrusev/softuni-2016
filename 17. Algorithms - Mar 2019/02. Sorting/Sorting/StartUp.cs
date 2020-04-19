namespace Sorting
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        static int[] collection = new int[10] { 2, 1, 5, 11, 4, 6, 20, 7, 3, 10 };  

        public static void Main()
        {
            Console.WriteLine(SelectionSort());

            Console.WriteLine(InsertionSort());

            Console.WriteLine(BubleSort());

            Console.WriteLine(ShellSort());

            Console.WriteLine(string.Join(", ", MergeSort(collection)));

            Console.WriteLine(QuickSort(collection.Clone() as int[], 0, collection.Length - 1));

            Console.WriteLine(BucketSort());
        }

        public static string SelectionSort()
        {
            int[] numbers = new int[collection.Length];
            collection.CopyTo(numbers, 0);

            int temp, smallest;

            for (int i = 0; i < numbers.Length - 1; i++)
            {
                smallest = i;

                for (int j = i + 1; j < numbers.Length; j++)
                {
                    if (numbers[j] < numbers[smallest])
                    {
                        smallest = j;
                    }
                }

                temp = numbers[smallest];
                numbers[smallest] = numbers[i];
                numbers[i] = temp;
            }

            return string.Join(", ", numbers);
        }

        public static string BucketSort()
        {
            int[] numbers = new int[collection.Length];
            collection.CopyTo(numbers, 0);

            int minValue = numbers[0];
            int maxValue = numbers[0];

            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] > maxValue)
                {
                    maxValue = numbers[i];
                }
                if (numbers[i] < minValue)
                {
                    minValue = numbers[i];
                }
            }

            List<int>[] bucket = new List<int>[maxValue - minValue + 1];

            for (int i = 0; i < bucket.Length; i++)
            {
                bucket[i] = new List<int>();
            }

            for (int i = 0; i < numbers.Length; i++)
            {
                bucket[numbers[i] - minValue].Add(numbers[i]);
            }

            int k = 0;
            for (int i = 0; i < bucket.Length; i++)
            {
                if (bucket[i].Count > 0)
                {
                    for (int j = 0; j < bucket[i].Count; j++)
                    {
                        numbers[k] = bucket[i][j];
                        k++;
                    }
                }
            }

            return string.Join(", ", numbers);
        }

        private static string QuickSort(int[] numbers, int left, int right)
        {
            if (left < right)
            {
                int pivot = Partition(numbers, left, right);

                if (pivot > 1)
                {
                    QuickSort(numbers, left, pivot - 1);
                }

                if (pivot + 1 < right)
                {
                    QuickSort(numbers, pivot + 1, right);
                }
            }

            return string.Join(", ", numbers);
        }

        private static int Partition(int[] numbers, int left, int right)
        {
            int pivot = numbers[left];

            while (true)
            {
                while (numbers[left] < pivot)
                {
                    left++;
                }

                while (numbers[right] > pivot)
                {
                    right--;
                }

                if (left < right)
                {
                    if (numbers[left] == numbers[right])
                    {
                        return right;
                    }

                    int temp = numbers[left];
                    numbers[left] = numbers[right];
                    numbers[right] = temp;
                }
                else
                {
                    return right;
                }
            }
        }

        private static int[] MergeSort(int[] numbers)
        {            
            int[] left;
            int[] right;
            int[] result = new int[numbers.Length];

            if (numbers.Length <= 1)
            {
                return numbers;
            }

            int midPoint = numbers.Length / 2;

            left = new int[midPoint];

            if (numbers.Length % 2 == 0)
            {
                right = new int[midPoint];
            }
            else
            {
                right = new int[midPoint + 1];
            }

            for (int i = 0; i < midPoint; i++)
            {
                left[i] = numbers[i];
            }

            int x = 0;

            for (int i = midPoint; i < numbers.Length; i++)
            {
                right[x] = numbers[i];
                x++;
            }

            left = MergeSort(left);
            right = MergeSort(right);

            result = Merge(left, right);
            return result;
        }

        private static int[] Merge(int[] left, int[] right)
        {
            int resultLength = right.Length + left.Length;
            int[] result = new int[resultLength];

            int indexLeft = 0, indexRight = 0, indexResult = 0;

            while (indexLeft < left.Length || indexRight < right.Length)
            {
                if (indexLeft < left.Length && indexRight < right.Length)
                {
                    if (left[indexLeft] <= right[indexRight])
                    {
                        result[indexResult] = left[indexLeft];
                        indexLeft++;
                        indexResult++;
                    }
                    else
                    {
                        result[indexResult] = right[indexRight];
                        indexRight++;
                        indexResult++;
                    }
                }
                else if (indexLeft < left.Length)
                {
                    result[indexResult] = left[indexLeft];
                    indexLeft++;
                    indexResult++;
                }
                else if (indexRight < right.Length)
                {
                    result[indexResult] = right[indexRight];
                    indexRight++;
                    indexResult++;
                }
            }
            return result;
        }

        private static string InsertionSort()
        {
            int[] numbers = new int[collection.Length];
            collection.CopyTo(numbers, 0);

            for (int i = 0; i < numbers.Length - 1; i++)
            {
                for (int j = i + 1; j > 0; j--)
                {
                    if (numbers[j - 1] > numbers[j])
                    {
                        int temp = numbers[j - 1];
                        numbers[j - 1] = numbers[j];
                        numbers[j] = temp;
                    }
                }
            }

            return string.Join(", ", numbers);
        }

        private static string BubleSort()
        {
            int[] numbers = new int[collection.Length];
            collection.CopyTo(numbers, 0);
            int temp;

            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = i + 1; j < numbers.Length; j++)
                {
                    if (numbers[i] > numbers[j])
                    {
                        temp = numbers[i];
                        numbers[i] = numbers[j];
                        numbers[j] = temp;
                    }
                }
            }

            return string.Join(", ", numbers);
        }

        private static string ShellSort()
        {
            int[] numbers = new int[collection.Length];
            collection.CopyTo(numbers, 0);

            int i, j, inc, temp;
            inc = 3;

            while (inc > 0)
            {
                for (i = 0; i < numbers.Length; i++)
                {
                    j = i;
                    temp = numbers[i];
                    while ((j >= inc) && (numbers[j - inc] > temp))
                    {
                        numbers[j] = numbers[j - inc];
                        j = j - inc;
                    }
                    numbers[j] = temp;
                }

                if (inc / 2 != 0)
                {
                    inc = inc / 2;
                }
                else if (inc == 1)
                {
                    inc = 0;
                }
                else
                {
                    inc = 1;
                }
            }

            return string.Join(", ", numbers);
        }
    }
}