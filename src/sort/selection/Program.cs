using System;

namespace selection
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new[] {3, 5, 8, 1, 2, 9, 4, 7, 6};
            
            Console.WriteLine(string.Join(", ", a));
            Sort(a);
            Console.WriteLine(string.Join(", ", a));
        }

        private static void Sort(int[] a)
        {
            for (int i = a.Length; i > 1; i--)
            {
                int max = 0;
                for (int j = 0; j < i ; j++)
                {
                    if (a[j] > a[max])
                    {
                        max = j;
                    }
                }

                Swap(a, max, i - 1);
            }
        }

        private static void Swap(int[] a, int l, int r)
        {
            var tmp = a[l];
            a[l] = a[r];
            a[r] = tmp;
        }
    }
}
