using System;
using System.Linq;

namespace bubble
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new[] {5, 2, 5, 6, -1, 11, 6, 4};

            var ac = a.Select(e => e).ToArray();
            ac.SortArray();
                        
            Console.WriteLine(string.Join(", ", ac));
            
            a.SortArrayRecursive();
            
            Console.WriteLine(string.Join(", ", a));
        }

    }

    public static class ArrayExtensions
    {
        public static void SortArray(this int[] a)
        {
            var swapped = false;
            var length = a.Length - 1;
            do
            {
                for (int i = 0; i < length; i++)
                {
                    if (a[i] > a[i + 1])
                    {
                        Swap(a, i, i + 1);
                        swapped = true;
                    }
                }
                length--;
            } while (swapped && length > 1);
        }
        
        public static void SortArrayRecursive(this int[] a)
        {
            var edge = a.Length;
            for (int i = 0; i < edge; edge--)
            {                
                Bubble(a, i, edge - 1);
            }    
        }

        private static void Bubble(int[] a, int i, int edge)
        {
            if (i == edge)
            {
                return;
            }
            if (a[i] > a[i + 1])
            {
                Swap(a, i, i + 1);
            }
            Bubble(a, i + 1, edge);
        }


        private static void Swap(int[] a, int lhs, int rhs)
        {
            var tmp = a[lhs];
            a[lhs] = a[rhs];
            a[rhs] = tmp;
        }
    }
}
