using System;
using System.Linq;

namespace quicksort
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new[] {3, 5, 8, 1, 2, 9, 4, 7, 6};            
            Console.WriteLine(string.Join(", ", a));

            var xa = SortExtraSpace(a);
            Console.WriteLine(string.Join(", ", xa));
            
            //Sort(a, 0, a.Length - 1);
            Console.WriteLine(string.Join(", ", a));
            
        }

        private static int[] SortExtraSpace(int[] a)
        {
            if (a.Length < 2)
            {
                return a;
            }
            var pivot = a.Length - 1;
            var r = a.Length - 2;
            for (int l = 0; l < pivot; l++)
            {
                if (a[l] < a[pivot])
                {
                    continue;
                }

                for (; r > l; r--)
                {
                    if (a[r] < a[pivot])
                    {
                        break;
                    }
                }
                Swap(a, l, r);

                if (l == r)
                {
                    break;
                }
            }
            Swap(a, r, pivot);
            
            return SortExtraSpace(a.Take(r - 1).ToArray())
                .Append(a[pivot])
                .Concat(SortExtraSpace(a.Skip(r + 1).ToArray()))
                .ToArray();

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
