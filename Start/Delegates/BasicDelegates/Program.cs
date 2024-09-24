using System;

namespace BasicDelegates
{
    // TODO: declare the delegate type
    public delegate string MyDelegate(int arg1, int arg2);

    class MyClass
    {
        // Delegates can be bound to instance members as well as
        // static class functions
        public string instanceMethod1(int arg1, int arg2)
        {
            return ((arg1 + arg2) * arg1).ToString();
        }
    }

    class Program
    {
        // TODO: Create functions to serve as delegate implementations
        public static string ConcatNumbers (int arg1, int arg2)
        {
            return arg1.ToString() + arg2.ToString();
        }

        public static string MultiplyNumbers (int arg1, int arg2)
        {
            return (arg1 * arg2).ToString();
        }

        static void Main(string[] args)
        {
            // TODO: exercise each delegate function
            MyDelegate f;

            f = ConcatNumbers;
            Console.WriteLine(f(3, 5));

            f = MultiplyNumbers;
            Console.WriteLine(f(3, 5));

            // TODO: Use an instance function of a class as a delegate
            MyClass o = new MyClass();

            f = o.instanceMethod1;
            Console.WriteLine(f(3, 5));

        }
    }
}
