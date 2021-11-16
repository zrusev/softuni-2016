using Invaders;

var comp = new Computer(100);

comp.AddInvader(new Invader(10, 5));
comp.Skip(1);

Console.WriteLine(comp.Invaders().ToList().Count);

comp.AddInvader(new Invader(10, 5));

Console.WriteLine(comp.Invaders().ToList().Count);
Console.WriteLine(comp.Energy);

comp.DestroyTargetsInRadius(4);

Console.WriteLine(comp.Invaders().ToList().Count);