<Query Kind="Statements" />

// C# Masterclass. 04. Expression Trees
// Parsing Expression Trees

// Create an expression tree.  
Expression<Func<int, bool>> exprTree = num => num < 5;

// Decompose the expression tree.  
ParameterExpression param = (ParameterExpression)exprTree.Parameters[0];
BinaryExpression operation = (BinaryExpression)exprTree.Body;
ParameterExpression left = (ParameterExpression)operation.Left;
ConstantExpression right = (ConstantExpression)operation.Right;

Console.WriteLine("Decomposed expression: {0} => {1} {2} {3}",
				  param.Name, left.Name, operation.NodeType, right.Value);