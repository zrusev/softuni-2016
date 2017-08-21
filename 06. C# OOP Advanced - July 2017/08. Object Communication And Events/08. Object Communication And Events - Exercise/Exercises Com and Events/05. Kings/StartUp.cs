namespace _05.Kings
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class StartUp
    {
        public static void Main()
        {
            SoldierList soldiers = new SoldierList();
            King king = new King(Console.ReadLine());

            string[] royalGuardNames = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var name in royalGuardNames)
            {
                RoyalGuard rg = new RoyalGuard(name);
                rg.SoldierDead += soldiers.HandleDeadSoldier;
                rg.SoldierDead += king.OnSoldierDeath;
                soldiers.Add(rg);
                king.KingAttacked += rg.OnKingAttack;
            }

            string[] footmanNames = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var name in footmanNames)
            {
                Footman fm = new Footman(name);
                fm.SoldierDead += soldiers.HandleDeadSoldier;
                fm.SoldierDead += king.OnSoldierDeath;
                soldiers.Add(fm);
                king.KingAttacked += fm.OnKingAttack;
            }

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "End")
            {
                var tokens = command.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (tokens[0] == "Attack")
                {
                    king.RespondToAttack();
                }
                else if (tokens[0] == "Kill")
                {
                    string name = tokens[1];
                    IDefender soldier = soldiers.First(x => x.Name == name);
                    soldier.TakeAttack();
                }
            }
        }
        public class Footman : IDefender
        {
            public event DeathEventHandler SoldierDead;

            public Footman(string name)
            {
                this.Name = name;
                this.Lives = 2;
            }

            public string Name { get; protected set; }

            public int Lives { get; protected set; }

            public void OnKingAttack(object sender, EventArgs args)
            {
                Console.WriteLine($"Footman {this.Name} is panicking!");
            }

            public void TakeAttack()
            {
                this.Lives--;

                if (this.Lives <= 0)
                {
                    OnDeath(new SoldierArgs(this, this.OnKingAttack));
                }
            }

            protected void OnDeath(SoldierArgs args)
            {
                SoldierDead?.Invoke(this, args);
            }
        }
        public delegate void KingUnderAttackEventHandler(object sender, EventArgs args);

        public delegate void DeathEventHandler(object sender, SoldierArgs args);

        public class King : IHuman
        {
            public event KingUnderAttackEventHandler KingAttacked;

            public King(string name)
            {
                this.Name = name;
            }

            public string Name { get; set; }

            public void RespondToAttack()
            {
                Console.WriteLine($"King {this.Name} is under attack!");
                OnKingAttacked(new EventArgs());
            }

            protected void OnKingAttacked(EventArgs args)
            {
                KingAttacked?.Invoke(this, args);
            }

            public void OnSoldierDeath(object sender, SoldierArgs args)
            {
                this.KingAttacked -= args.OnKingAttack;
            }
        }
        public class RoyalGuard : IDefender
        {
            public event DeathEventHandler SoldierDead;

            public RoyalGuard(string name)
            {
                this.Name = name;
                this.Lives = 3;
            }

            public string Name { get; protected set; }

            public int Lives { get; protected set; }

            public void OnKingAttack(object sender, EventArgs args)
            {
                Console.WriteLine($"Royal Guard {this.Name} is defending!");
            }

            public void TakeAttack()
            {
                this.Lives--;

                if (this.Lives <= 0)
                {
                    OnDeath(new SoldierArgs(this, this.OnKingAttack));
                }
            }

            protected void OnDeath(SoldierArgs args)
            {
                SoldierDead?.Invoke(this, args);
            }
        }
        public class SoldierArgs : EventArgs
        {
            public SoldierArgs(IDefender soldier, KingUnderAttackEventHandler onKingAttack)
            {
                this.Soldier = soldier;
                this.OnKingAttack = onKingAttack;
            }

            public IDefender Soldier { get; private set; }

            public KingUnderAttackEventHandler OnKingAttack { get; private set; }
        }
        public class SoldierList : List<IDefender>
        {
            public void HandleDeadSoldier(object sender, SoldierArgs args)
            {
                this.Remove(args.Soldier);
            }
        }
        public interface IDefender : IHuman
        {
            event DeathEventHandler SoldierDead;

            int Lives { get; }

            void OnKingAttack(object sender, EventArgs args);

            void TakeAttack();
        }
        public interface IHuman
        {
            string Name { get; }
        }
    }
}
