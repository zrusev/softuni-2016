namespace SortingEnhanced
{
    using System;

    public static class MergeSort
    {
        public static void Sort(int[] input, int left, int right)
        {
            if (left < right)
            {
                var middle = (left + right) / 2;

                Sort(input, left, middle);
                Sort(input, middle + 1, right);

                Merge(input, left, middle, right);
            }
        }

        private static void Merge(int[] input, int left, int middle, int right)
        {
            var leftArray = new int[middle - left + 1];
            var rightArray = new int[right - middle];

            Array.Copy(input, left, leftArray, 0, middle - left + 1);
            Array.Copy(input, middle + 1, rightArray, 0, right - middle);

            var i = 0;
            var j = 0;

            for (var k = left; k < right + 1; k++)
            {
                if (i == leftArray.Length)
                {
                    input[k] = rightArray[j];
                    j++;
                }
                else if (j == rightArray.Length)
                {
                    input[k] = leftArray[i];
                    i++;
                }
                else if (leftArray[i] <= rightArray[j])
                {
                    input[k] = leftArray[i];
                    i++;
                }
                else
                {
                    input[k] = rightArray[j];
                    j++;
                }
            }
        }
    }
}
