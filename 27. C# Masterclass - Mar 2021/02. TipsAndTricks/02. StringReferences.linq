<Query Kind="Statements" />

// C# Masterclass. 02. C# Tips and Tricks
// String References

string s1 = "test string";
string s2 = "test string";
string s3 = "another string";
string s4 = Console.ReadLine();
//string s4 = string.Intern(Console.ReadLine());

object.ReferenceEquals(s1, s2).Dump("S1 ReferenceEquals S2");
object.ReferenceEquals(s1, s3).Dump("S1 ReferenceEquals S3");
object.ReferenceEquals(s1, s4).Dump("S1 ReferenceEquals S4");
object.Equals(s1, s4).Dump("S1 Equals S4");
(s1 == s4).Dump("S1 == S4");