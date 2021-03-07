namespace _04.CookiesProblem
{
    using Wintellect.PowerCollections;

    public class CookiesProblem
    {
        public int Solve(int k, int[] cookies)
        {
            var priorityQueue = new OrderedBag<int>();

            foreach (var cookie in cookies)
            {
                priorityQueue.Add(cookie);
            }

            int currentMinSweetness = priorityQueue[0];
            int steps = 0;

            while (currentMinSweetness < k
                && priorityQueue.Count > 1)
            {
                int leastSweetCookie = priorityQueue.RemoveFirst();
                int secondLeastSweetCookie = priorityQueue.RemoveFirst();

                int combined = leastSweetCookie + 2 * secondLeastSweetCookie;

                priorityQueue.Add(combined);

                currentMinSweetness = priorityQueue.GetFirst();
                
                steps++;
            }

            return currentMinSweetness < k ? -1 : steps;
        }
    }
}
