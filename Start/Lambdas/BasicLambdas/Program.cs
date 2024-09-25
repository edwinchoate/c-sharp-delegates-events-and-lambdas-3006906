using System;

namespace BasicLambdas
{
    // define a few delegate types
    public delegate int MyDelegate(int x);
    public delegate void MyDelegate2(int x, string prefix);
    public delegate bool ExprDelegate(int x);

    class Program
    {
        static void Main(string[] args)
        {
            // TODO: Create a basic delegate that squares a number
            MyDelegate sq = (x) => x * x;

            Console.WriteLine(sq(4));

            // TODO: Dynamically change the delegate to something else
            sq = (x) => (int)Math.Pow(x, 2);

            Console.WriteLine(sq(4));

            // TODO: Create a delegate that takes multiple arguments
            MyDelegate2 f = (x, p) =>
            {
                Console.WriteLine("{0}{1}", p, x);
            }; 

            f(5, "~");

            // TODO: Define an expression delegate
            ExprDelegate f2 = (x) => x > 10;

            Console.WriteLine(f2(15));
        }
    }
}