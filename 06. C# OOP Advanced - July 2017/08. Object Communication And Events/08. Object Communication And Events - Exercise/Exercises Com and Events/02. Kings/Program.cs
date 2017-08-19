namespace _02.Kings
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            List<Soldier> army = new List<Soldier>();
            King king = new King(Console.ReadLine());

            string[] royalGuards = Console.ReadLine().Split();
            foreach (var royalGuard in royalGuards)
            {
                RoyalGuard guard = new RoyalGuard(royalGuard);
                army.Add(guard);
                king.UnderAttack += guard.KingUnderAttack;
            }

            string[] footmen = Console.ReadLine().Split();
            foreach (var footman in footmen)
            {
                Footman foot = new Footman(footman);
                army.Add(foot);
                king.UnderAttack += foot.KingUnderAttack;
            }

            string[] command = Console.ReadLine().Split();
            while (command[0] != "End")
            {
                switch (command[0])
                {
                    case "Kill":
                        Soldier soldier = army.FirstOrDefault(s => s.Name == command[1]);
                        king.UnderAttack -= soldier.KingUnderAttack;
                        army.Remove(soldier);
                        break;
                    case "Attack":
                        king.OnUnderAttack();
                        break;
                }
                command = Console.ReadLine().Split();
            }
        }
    }

    public abstract class Soldier
    {
        public Soldier(string name)
        {
            this.Name = name;
        }

        public string Name { get; private set; }

        public abstract void KingUnderAttack(object sender, EventArgs e);
    }

    public class RoyalGuard : Soldier
    {
        public RoyalGuard(string name) : base(name)
        {
        }

        public override void KingUnderAttack(object sender, EventArgs e)
        {
            Console.WriteLine($"Royal Guard {this.Name} is defending!");
        }
    }

    public class King
    {
        public event EventHandler UnderAttack;

        public King(string name)
        {
            this.Name = name;
        }

        public string Name { get; private set; }

        public void OnUnderAttack()
        {
            Console.WriteLine($"King {this.Name} is under attack!");

            if (UnderAttack != null)
            {
                UnderAttack(this, new EventArgs());
            }
        }
    }

    public class Footman : Soldier
    {
        public Footman(string name) : base(name)
        {
        }

        public override void KingUnderAttack(object sender, EventArgs e)
        {
            Console.WriteLine($"Footman {this.Name} is panicking!");
        }
    }
}
