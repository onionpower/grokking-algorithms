using System;
using System.Linq;

namespace longest_inc_sequence
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new[] { 3, -1, 4, 3, 7, -2, 5, 6 };
            
            var w = a.Select(e => 1).ToArray();

            for (int i = 0; i < a.Length; i++)
            {
                for (int j = i + 1; j < a.Length; j++)
                {
                    if (a[i] >= a[j])
                    {
                        continue;
                    }

                    if (w[j] >= w[i] + 1)
                    {
                        continue;
                    }

                    w[j]++;
                }
            }
            
            Console.WriteLine(string.Join(", ", a));
            Console.WriteLine(string.Join(", ", w));
        }
    }
}
