using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Problem01
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            Func<int, int, bool> Unlocked = (b, l) => b <= l == true;

            var pricePerBullet = int.Parse(Console.ReadLine());
            var sizeOfBarrel = int.Parse(Console.ReadLine());
            var bullets = new Stack<int>(Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());
            var totalBulletsCount = bullets.Count;

            var locks = new Queue<int>(Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());
            var intelligence = int.Parse(Console.ReadLine());

            var barrelCounter = 0;
            do
            {
                var IsUnlocked = Unlocked(bullets.Peek(), locks.Peek());

                if (IsUnlocked)
                {
                    Console.WriteLine("Bang!");
                    locks.Dequeue();
                }
                else
                {
                    Console.WriteLine("Ping!");
                }

                bullets.Pop();
                barrelCounter++;

                if (barrelCounter >= sizeOfBarrel && bullets.Count > 0)
                {
                    Console.WriteLine("Reloading!");
                    barrelCounter = 0;
                }
                
            } while (bullets.Count > 0 && locks.Count > 0);

            if (bullets.Count == 0 && locks.Count > 0)
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
            }
            else
            {
                var moneyEarned = intelligence - ((totalBulletsCount - bullets.Count) * pricePerBullet);
                Console.WriteLine($"{bullets.Count} bullets left. Earned ${moneyEarned}");
            }
        }
    }
}
