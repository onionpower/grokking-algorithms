using System;
using System.Collections.Generic;
using System.Linq;

namespace mergesort
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new int[] {3, 4, 7, 6, 8, 2, 1, -1, 9, 5};
            WriteArray(a);
            WriteArray(Sort(a));
        }

        private static int[] Sort(int[] a)
        {
            var lcount = GetBiggerHalf(a);
            var res = Merge(a.Take(lcount).ToArray(), a.Skip(lcount).ToArray());
            
            return res;
        }

        private static int[] Merge(int[] l, int[] r)
        {
            if (l.Length > 2)
            {
                var lcount = GetBiggerHalf(l);
                l = Merge(l.Take(lcount).ToArray(), l.Skip(lcount).ToArray());
            }

            if (r.Length > 2)
            {
                var rcount = GetBiggerHalf(r);
                r = Merge(r.Take(rcount).ToArray(), r.Skip(rcount).ToArray());
            }
            var res = new int[l.Length + r.Length];
            var i = 0;
            for (int t = 0;i < r.Length; i++, t+=2)
            {
                if (l[i] < r[i])
                {
                    res[t] = l[i];
                    res[t + 1] = r[i];
                }
                else
                {
                    res[t] = r[i];
                    res[t + 1] = l[i];
                }
            }

            if (i < l.Length)
            {
                res[i+1] = l[i];
            }

            return res;
        }

        static int GetBiggerHalf(int[] a)
        {
            return (a.Length + 1) / 2;
        }
        
        static void Swap(int[] a, int l, int r)
        {
            var tmp = a[l];
            a[l] = a[r];
            a[r] = tmp;
        }

        static void WriteArray(IEnumerable<int> a)
        {
            Console.WriteLine(string.Join(", ", a));
        }
    }
}
