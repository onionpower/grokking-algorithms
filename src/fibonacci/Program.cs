using System;
using System.Diagnostics;

namespace fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            //1 1 2 3 5 8 13
            Watch(Fib, 45);
            Watch(FibMemo, 45);
        }

        private static int Watch(Func<int, int> f, int n)
        {
            var sw = Stopwatch.StartNew();
            var r = f(n);
            sw.Stop();
            Console.WriteLine(sw.Elapsed.TotalSeconds);
            Console.WriteLine($"fibonacchi {n}th number is {r}");
            return r;
        }
        
        private static int Fib(int i)
        {
            if (i < 3)
            {
                return 1;
            }

            return Fib(i - 1) + Fib(i - 2);
        }

        private static int[] _memo;
        private static int FibMemo(int i)
        {
            _memo = new int[i + 1];
            var r = RecFib(i);
            return r;
        }

        private static int RecFib(int i)
        {
            if (i < 3)
            {
                return 1;
            }

            if (_memo[i] != 0)
            {
                return _memo[i];
            }

            var r = RecFib(i - 1) + RecFib(i - 2);
            _memo[i] = r;
            return r;
        }
    }
}
