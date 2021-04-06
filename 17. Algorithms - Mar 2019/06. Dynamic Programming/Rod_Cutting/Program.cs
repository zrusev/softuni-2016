namespace Rod_Cutting
{
    using System;

    public class Program
    {
        private static int[] bestPrice;
        private static int[] price;
        private static int[] bestCombo;


        private static int CutRod(int n)
        {
            if(bestPrice[n] >= 0)
            {
                return bestPrice[n];
            }

            if (n == 0)
            {
                return 0;
            }

            var currentBest = bestPrice[n];

            for (int i = 1; i < n; i++)
            {
                currentBest = Math.Max(currentBest, price[i] + CutRod(n - 1));

                if (currentBest > bestPrice[n])
                {
                    bestPrice[n] = currentBest;
                    bestCombo[n] = i;
                }
            }

            return bestPrice[n];
        }

        public static void Main()
        {
            int n = 3;
            bestPrice = new int[n];
            price = new int[n];
            bestCombo = new int[n];

            CutRod(n);
        }
    }
}
