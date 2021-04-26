<Query Kind="Statements" />

// C# Masterclass. 04. Expression Trees
// Use runtime state from within the expression tree

var companyNames = new[] {
	"Consolidated Messenger", "Alpine Ski House", "Southridge Video",
	"City Power & Light", "Coho Winery", "Wide World Importers",
	"Graphic Design Institute", "Adventure Works", "Humongous Insurance",
	"Woodgrove Bank", "Margie's Travel", "Northwind Traders",
	"Blue Yonder Airlines", "Trey Research", "The Phone Company",
	"Wingtip Toys", "Lucerne Publishing", "Fourth Coffee"
};

var length = 1;
var qry = companyNames
	.AsQueryable()
	.Select(x => x.Substring(0, length))
	.Distinct();

string.Join(", ", qry).Dump("Length = 1");
// prints: C, A, S, W, G, H, M, N, B, T, L, F

length = 2;
string.Join(", ", qry).Dump("Length = 2");
// prints: Co, Al, So, Ci, Wi, Gr, Ad, Hu, Wo, Ma, No, Bl, Tr, Th, Lu, Fo