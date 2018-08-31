using System;
using System.Collections.Generic;
using System.Linq;

namespace quicksort
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new[] {3, 5, 8, 1, 2, 9, 4, 7, 6};            
            Console.WriteLine(string.Join(", ", a));

            var xa = SortExtraSpace(a.ToList());
            Console.WriteLine(string.Join(", ", xa));
            
            //Sort(a, 0, a.Length - 1);
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
            var pivot = a.Count - 1;
            for (int i = 0; i < a.Count - 1; i++)
            {
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
        
        private static void Sort(int[] a, int start, int end)
        {
            if (end - start == 1)
            {
                return;
            }
            
            var pivot = end;
            var rhs = end - 1;
            var lhs = start;
            while (lhs < end)
            {
                if (a[lhs] < a[pivot])
                {
                    lhs++;
                    continue;
                }
    
                while (a[rhs] > a[pivot] && rhs > lhs)
                {
                    rhs--;
                }

                if (rhs == lhs)
                {
                    Swap(a, lhs, pivot);
                    break;
                }
                Swap(a, lhs++, rhs);
            }
            
            Sort(a, start, lhs - 1);
            Sort(a, lhs + 1, end);
        }

        private static void Swap(int[] a, int lhs, int rhs)
        {
            var tmp = a[lhs];
            a[lhs] = a[rhs];
            a[rhs] = tmp;
        }
    }
}
