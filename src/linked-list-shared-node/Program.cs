using System;
using System.Collections.Generic;

namespace linked_list_shared_node
{
    class Program
    {
        private static LinkedList<object> ll1 = new LinkedList<object>();
        private static LinkedList<object> ll2 = new LinkedList<object>();
        private static object shared = Guid.NewGuid();
        
        static void Main(string[] args)
        {
            Init();
            if (TryBruteForce(out var rb))
            {
                IsShared(rb);
            }

            if (TryHashSet(out var rh))
            {
                IsShared(rh);
            }
            
        }

        private static void IsShared(object o)
        {
            Console.WriteLine(shared.Equals(o));
        }

        private static bool TryHashSet(out object r)
        {
            var p1 = ll1.First;
            var p2 = ll2.First;
            var set = new HashSet<object>();
            while (true)
            {
                if (p1 == null && p2 == null)
                {
                    r = null;
                    return false;
                }
                
                if (p1 != null)
                {
                    if (!set.Add(p1.Value))
                    {
                        if (p1.Value is Guid)
                        {
                            r = p1.Value;
                            return true;
                        }
                    }

                    p1 = p1.Next;
                }

                if (p2 != null)
                {
                    if (!set.Add(p2.Value))
                    {
                        if (p2.Value is Guid)
                        {
                            r = p2.Value;
                            return true;
                        }
                    }

                    p2 = p2.Next;
                }
            }
        }
        
        private static bool TryBruteForce(out object r)
        {
            foreach (var p1 in ll1)
            {
                foreach (var p2 in ll2)
                {
                    if (p1 is Guid && p2 is Guid)
                    {
                        r = p1;
                        return true;
                    }
                }
            }

            r = null;
            return false;
        }

        private static void Init()
        {
            for (int i = 0; i < 4; i++)
            {
                ll1.AddLast(i);
            }

            ll1.AddLast(shared);
            for (int i = 0; i < 3; i++)
            {
                ll1.AddLast(i);
            }

            for (int i = 0; i < 5; i++)
            {
                ll2.AddLast(i);
            }

            ll2.AddLast(shared);
            for (int i = 0; i < 2; i++)
            {
                ll2.AddLast(i);
            }
        }
    }
}
