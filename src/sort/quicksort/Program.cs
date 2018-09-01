using System;
using System.Collections.Generic;
using System.Linq;

namespace quicksort
{
    class Program
    {
        static Random rnd = new Random();
        static void Main(string[] args)
        {
            var a = new[] {3, 5, 8, 1, 2, 9, 4, 7, 6};            
            Console.WriteLine(string.Join(", ", a));

            var xa = SortExtraSpace(a.ToList());
            Console.WriteLine(string.Join(", ", xa));
            
            SortRecursive(a, 0, a.Length);
            Console.WriteLine(string.Join(", ", a));
            
        }

        private static List<int> SortExtraSpace(List<int> a)
        {
            if (a.Count < 2)
            {
                return a;
            }

            var left = new List<int>();
            var right = new List<int>();
            var pivot = rnd.Next(0, a.Count);
            for (int i = 0; i < a.Count; i++)
            {
                if (i == pivot)
                {
                    continue;
                }
                if (a[i] < a[pivot])
                {
                    left.Add(a[i]);
                    continue;
                }
                right.Add(a[i]);
            }

            var r = SortExtraSpace(left);
            r.Add(a[pivot]);
            r.AddRange(SortExtraSpace(right));
            return r;
        }
        
        private static void SortRecursive(int[] a, int start, int length)
        {
            if (length - start < 2)
            {
                return;
            }
            
            var pivot = length - 1;
            var lm = start;
            var rm = pivot - 1;
            for (;lm < pivot; lm++)
            {
                if (a[lm] > a[pivot])
                {
                    for (;rm > lm; rm--)
                    {
                        if (a[rm] < a[pivot])
                        {
                            Swap(a, lm, rm);
                            break;
                        }
                    }

                    if (rm <= lm)
                    {
                        break;
                    }
                }
            }
            Swap(a, lm, pivot);
            SortRecursive(a, start, lm - start);
            SortRecursive(a, lm + 1, pivot);
        }

        private static void Swap(int[] a, int lhs, int rhs)
        {
            var tmp = a[lhs];
            a[lhs] = a[rhs];
            a[rhs] = tmp;
        }
    }
}
