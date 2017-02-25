namespace _11.Dragon_Army
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Dragon_Army
    {
        static void Main()
        {

            var dragonds = new Dictionary<string, SortedDictionary<string, decimal[]>>();

            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var tokens = Console.ReadLine().Split();

                var type = tokens[0];
                var name = tokens[1];

                var damage = 0m;
                if (tokens[2] != "null")
                {
                    damage = decimal.Parse(tokens[2]);
                }
                else
                {
                    damage = 45;

                }

                var health = 0m;
                if (tokens[3] != "null")
                {
                    health = decimal.Parse(tokens[3]);
                }
                else
                {
                    health = 250;
                }

                var armor = 0m;
                if (tokens[4] != "null")
                {
                    armor = decimal.Parse(tokens[4]);
                }
                else
                {
                    armor = 10;
                }

                if (!dragonds.ContainsKey(type))
                {
                    dragonds[type] = new SortedDictionary<string, decimal[]>();
                }
                
                dragonds[type][name] = new decimal[] {damage, health, armor};
            }

            foreach (var type in dragonds)
            {
                var typeName = type.Key;
                var dragonsByType = type.Value;

                var avgDamage = dragonsByType.Values.Average(a => a[0]);
                var avgHealth = dragonsByType.Values.Average(a => a[1]);
                var avgArmor = dragonsByType.Values.Average(a => a[2]);

                Console.WriteLine($"{typeName}::({avgDamage:F2}/{avgHealth:F2}/{avgArmor:F2})");

                foreach (var dragon in dragonsByType)
                {
                    var name = dragon.Key;
                    var stats = dragon.Value;
                    var damage = stats[0];
                    var health = stats[1];
                    var armor = stats[2];

                    Console.WriteLine($"-{name} -> damage: {damage}, health: {health}, armor: {armor}");
                }
            }
        }
    }
}
