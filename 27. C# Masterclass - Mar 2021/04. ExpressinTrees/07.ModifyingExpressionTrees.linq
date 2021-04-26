<Query Kind="Statements" />

// C# Masterclass. 04. Expression Trees
// Modifying expression trees

Expression<Func<string, bool>> expr = name => name.Length > 10 && name.StartsWith("P");

AndAlsoModifier treeModifier = new AndAlsoModifier();
Expression<Func<string, bool>> modifiedExpr = treeModifier.Modify((Expression)expr) 
	as Expression<Func<string, bool>>;

expr.Compile()("Pesho")
	.Dump("name => ((name.Length > 10) && name.StartsWith(\"P\"))");
	
modifiedExpr.Compile()("Pesho")
	.Dump("name => ((name.Length > 10) || name.StartsWith(\"P\"))");
	

public class AndAlsoModifier : ExpressionVisitor
{
	public Expression Modify(Expression expression)
	{
		return Visit(expression);
	}

	protected override Expression VisitBinary(BinaryExpression b)
	{
		if (b.NodeType == ExpressionType.AndAlso)
		{
			Expression left = this.Visit(b.Left);
			Expression right = this.Visit(b.Right);

			// Make this binary expression an OrElse operation instead of an AndAlso operation.  
			return Expression.MakeBinary(ExpressionType.OrElse, left, right, b.IsLiftedToNull, b.Method);
		}

		return base.VisitBinary(b);
	}
}