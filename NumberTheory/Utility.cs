using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NumberTheory.ContinuedFraction;

namespace NumberTheory
{
    public class Utility
    {
        public static bool IsOdd(long number)
        {
            return number % 2 == 1;
        }

        public static bool IsPeriodic(List<int> array, out List<int> begin, out List<int> period)
        {
            begin = new List<int>();
            period = new List<int>();
            if (array == null || array.Count == 0)
                return false;

            PeriodFormat pf = new PeriodFormat(array.ToArray());
            var AB = pf.GetPeriodStr();

            if (AB == null || AB.Count < 2)
                return false;

            string A_Str = AB[0];
            string[] As = A_Str.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var a in As)
            {
                begin.Add(int.Parse(a.Trim()));
            }

            string[] Bs = AB[1].TrimStart('[').TrimEnd(']').Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            if (Bs == null || Bs.Length == 0 || Bs[0] == string.Empty)
                return false;

            foreach (var b in Bs)
            {
                period.Add(int.Parse(b.Trim()));
            }

            return true;
        }
    }
}
