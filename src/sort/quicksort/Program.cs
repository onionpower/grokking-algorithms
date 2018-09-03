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
            var a = new[] {3, 5, 8, 1, 2, 9, 4, -1, 17, 22, 7, 6, 14, 14, 14};            
            WriteArray(a);

            var xa = SortExtraSpace(a.ToList());
            WriteArray(xa);
            
            SortRecursive(a);
            WriteArray(a);
            
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

        private static void SortRecursive(int[] a)
        {
            SortRecursive(a, 0, a.Length - 1);            
        }
        
        private static void SortRecursive(int[] a, int sp, int ep)
        {
            if (ep - sp < 1)
            {
                return;
            }

            var lm = sp;
            var rm = ep - 1;
            var pivot = ep;
            for (;lm < ep; lm++)
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

                    if (lm == rm)
                    {
                        break;
                    }
                }
            }

            Swap(a, lm, pivot);
            SortRecursive(a, sp, lm - 1);
            SortRecursive(a, lm + 1, ep);
        }

        private static void Swap(int[] a, int lhs, int rhs)
        {
            var tmp = a[lhs];
            a[lhs] = a[rhs];
            a[rhs] = tmp;
        }

        private static void WriteArray(IEnumerable<int> a)
        {
            Console.WriteLine(string.Join(", ", a));
        }
    }
}
