namespace _05.Bomb_Numbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Bomb_Numbers
    {
        static void Main()
        {
            List<int> nums = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToList();
            List<int> para = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToList();
            int spec = para[0];
            int power = para[1];
            for (int i = 0; i < nums.Count; i++)
            {
                if (nums[i] == spec)
                    for (int p = -power; p <= power; p++)
                        if (i + p >= 0 && i + p < nums.Count)
                            nums[i + p] = 0;

            }

            Console.WriteLine(nums.Sum());
        }
    }
}
