<Query Kind="Statements" />

// C# Masterclass. 02. C# Tips and Tricks
// References in .NET

object o1 = 5;
object o2 = 5;
object o3 = o1;

object.ReferenceEquals(o1, o2).Dump("o1 ReferenceEquals o2");
(o1 == o2).Dump("o1 == o2");

object.Equals(o1, o2).Dump("o1 Equals o2");

object.ReferenceEquals(o1, o3).Dump("o1 ReferenceEquals o3");
(o1 == o3).Dump("o1 == o3");

object.Equals(o1, o3).Dump("o1 Equals o3");