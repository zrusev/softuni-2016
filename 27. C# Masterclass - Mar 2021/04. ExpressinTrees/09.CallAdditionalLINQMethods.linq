<Query Kind="Statements" />

// C# Masterclass. 04. Expression Trees
// Call additional LINQ methods

var companyNames = new[] {
	"Consolidated Messenger", "Alpine Ski House", "Southridge Video",
	"City Power & Light", "Coho Winery", "Wide World Importers",
	"Graphic Design Institute", "Adventure Works", "Humongous Insurance",
	"Woodgrove Bank", "Margie's Travel", "Northwind Traders",
	"Blue Yonder Airlines", "Trey Research", "The Phone Company",
	"Wingtip Toys", "Lucerne Publishing", "Fourth Coffee"
};

bool sortByLength = true;

var qry = companyNames.AsQueryable();

if (sortByLength)
{
	qry = qry.OrderBy(x => x.Length);
}

qry.ToList().Dump("Processed list");