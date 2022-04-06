namespace SortingEnhanced
{
    public class QuickSort
    {
        public static void Sort(int[] arr, int lo, int hi)
        {
            if (hi - lo < 40)
            {
                InsertionSort(arr, lo, hi);
            }
            else
            {
                var part = Partition(arr, lo, hi);
                Sort(arr, lo, part - 1);
                Sort(arr, part + 1, hi);
            }
        }

        private static int Partition(int[] arr, int lo, int hi)
        {
            var j = lo;
            var pivot = arr[lo];

            for (int i = lo; i <= hi; i++)
            {
                if (arr[i].CompareTo(pivot) >= 0)
                {
                    continue;
                }

                j++;
                Swap(arr, i, j);
            }

            Swap(arr, lo, j);
            return j;
        }

        private static void InsertionSort(int[] arr, int lo, int hi)
        {
            for (var i = lo + 1; i <= hi; i++)
            {
                var j = i - 1;
                var x = arr[i];

                while (j >= 0 && arr[j].CompareTo(x) > 0)
                {
                    arr[j + 1] = arr[j];
                    j--;
                }

                arr[j + 1] = x;
            }
        }

        private static void Swap(int[] arr, int i, int j)
        {
            var temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
    }
}
