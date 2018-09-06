using System;

namespace insertion
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new[] {3, 1, 2, 4, 7, 0, -1, 8, 9, 5, 6};
            WriteArray(a);
            var sa = Sort(a);
            WriteArray(sa);
        }

        private static int[] Sort(int[] a)
        {
            var sa = new int[a.Length];
            for (int i = 0; i < a.Length; i++)
            {
                int j = 0;
                for (; j < i; j++)
                {
                    if (a[i] < sa[j])
                    {
                        for (int k = j, movable = sa[k]; k < i; k++)
                        {
                            var next = sa[k + 1];
                            sa[k + 1] = movable;
                            movable = next;
                        }
                        break;
                    }
                }
                sa[j] = a[i];
            }

            return sa;
        }

        static void WriteArray(int[] a)
        {
            Console.WriteLine(string.Join(", ", a));
        }
    }
}
