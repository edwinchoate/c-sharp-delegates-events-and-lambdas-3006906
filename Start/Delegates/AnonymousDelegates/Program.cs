using System;

namespace AnonymousDelegates
{
    public delegate string MyDelegate(int arg1, int arg2);

    class Program
    {
        static void Main(string[] args)
        {
            // TODO: Implement an anonymous delegate
            MyDelegate f = delegate(int arg1, int arg2) 
            {
                return (arg1 + arg2).ToString();
            };

            Console.WriteLine(f(10, 20));
        }
    }
}
