using System;
using System.Collections.Generic;
using System.Linq;

namespace two_iterators
{
    class Program
    {
        static void Main(string[] args)
        {
            var e = new List<int>();
            
            var fl = new List<int>();
            for (int i = 0; i < 15; i++)
            {
                fl.Add(i);
            }

            fl.ForEach(i => e.Add(i));
            
            var sl = new List<int>();
            for (int i = 0; i < 30; i+=2)
            {
                sl.Add(i);
            }
            
            sl.ForEach(i => e.Add(i));
            PrintLn(e);
            e.Sort();
            PrintLn(e);

            var f = fl.GetEnumerator();
            var s = sl.GetEnumerator();
            
            var r = new LinkedList<int>();

            f.MoveNext();
            s.MoveNext();
            while (true)
            {
                if (f.Current < s.Current)
                {
                    r.AddLast(f.Current);
                    if (!f.MoveNext())
                    {
                        r.AddLast(s.Current);
                        while (s.MoveNext())
                        {
                            r.AddLast(s.Current);
                        }

                        break;
                    }
                }
                else
                {
                    r.AddLast(s.Current);
                    if (!s.MoveNext())
                    {                       
                        r.AddLast(f.Current);
                        while (f.MoveNext())
                        {
                            r.AddLast(f.Current);
                        }

                        break;                        
                    }
                }
            }
            
            PrintLn(r);
            f.Dispose();
            s.Dispose();
        }

        static void PrintLn(IEnumerable<int> a)
        {
            Console.WriteLine(string.Join(", ", a));
        }
    }
}
