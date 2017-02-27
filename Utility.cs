using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public static class Utility
    {
        public static List<int> RandomIntegers(int capacity, int max)
        {
            Random r = new Random();
            List<int> result = new List<int>();
            for (int i = 0; i < capacity; i++)
            {
                result.Add(r.Next(1, max));
            }
            return result;
        }

        public static void Exchange<T>(ref T t1, ref T t2) where T: struct
        {
            var temp = t1;
            t1 = t2;
            t2 = temp;
        }
    }
}
