using System;
using System.Collections.Generic;
using System.ComponentModel;
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
            if (l.Length > 1)
            {
                var lcount = GetBiggerHalf(l);
                l = Merge(l.Take(lcount).ToArray(), l.Skip(lcount).ToArray());
            }

            if (r.Length > 1)
            {
                var rcount = GetBiggerHalf(r);
                r = Merge(r.Take(rcount).ToArray(), r.Skip(rcount).ToArray());
            }
            var res = new int[l.Length + r.Length];
            var resp = 0;
            int lp = 0;
            int rp = 0;
            for (; lp < l.Length && rp < r.Length; resp++)
            {
                if (l[lp] < r[rp])
                {
                    res[resp] = l[lp];
                    lp++;
                }
                else
                {
                    res[resp] = r[rp];
                    rp++;
                }
            }

            for (; lp < l.Length; lp++, resp++)
            {
                res[resp] = l[lp];
            }
            for (; rp < r.Length; rp++, resp++)
            {
                res[resp] = r[rp];
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
