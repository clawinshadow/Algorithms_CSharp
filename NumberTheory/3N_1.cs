using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberTheory
{
    //计算3N+1算法的长度与终止值
    public class _3N_1
    {
        private static readonly int MAX_COUNT = 1000;
        private static readonly int MAX_NUMBER = 100;

        public static void Run()
        {
            Console.WriteLine("3N + 1 Algorithm Demo");
            Console.WriteLine(string.Format("{0,6} {1,6} {2,6} {3,-60} {4,30}",
                "Number", "Depth", "End", "Part A", "Part B"));
            for (int i = 1; i <= MAX_NUMBER; i++)
            {
                Console.WriteLine(Calculate(i));
            }

            Console.ReadKey();
        }


        private static List<int> GenerateArray(int number)
        {
            List<int> result = new List<int>();
            result.Add(number);

            int count = 0;
            int temp;
            while (count < 1000)
            {
                temp = GetNextNumber(number);
                result.Add(temp);

                number = temp;
                count++;
            }

            return result;
        }

        private static string Calculate(int number)
        {
            List<int> array = GenerateArray(number);

            List<int> begin;
            List<int> period;
            Utility.IsPeriodic(array, out begin, out period);

            string s = "";
            if (begin.Count > 0)
                begin.ForEach(item => s += item.ToString() + ",");
            string p = "";
            if (period.Count> 0)
                period.ForEach(item => p += item.ToString() + ",");

            return string.Format("{0,6} {1,6} {2,6} {3,-60} {4,-30}", 
                number, begin.Count, begin.Count == 0 ? number : begin.Last(), s.TrimEnd(','), p.TrimEnd(','));
        }

        private static int GetNextNumber(int number)
        {
            if (Utility.IsOdd(number))
                return 3 * number + 1;
            else
                return number / 2;
        }
    }
}
