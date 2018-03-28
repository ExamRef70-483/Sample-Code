using System;
using System.Linq.Expressions;

namespace LISTING_2_58_Lambda_expression_tree
{
    class Program
    {
        static void Main(string[] args)
        {
            // build the expression tree: Expression<Func<int,int>> square = num => num * num;

            // The parameter for the expression is an integer
            ParameterExpression numParam = Expression.Parameter(typeof(int), "num");

            // The opertion to be performed is to square the parameter
            BinaryExpression squareOperation = Expression.Multiply(numParam,numParam);

            // This creates an expression tree that describes the square operation
            Expression<Func<int, int>> square =
                Expression.Lambda<Func<int, int>>(
                    squareOperation,
                    new ParameterExpression[] { numParam });

            // Compile the tree to make an executable method and assign it to a delegate
            Func<int, int> doSquare = square.Compile();

            // Call the delegate
            Console.WriteLine("Square of 2: {0}", doSquare(2));

            Console.ReadKey();
        }
    }
}
