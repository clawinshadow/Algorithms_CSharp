using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberTheory
{
    /// <summary>
    /// 用逐次平方法计算幂模 a^p (mod m)
    /// </summary>
    public class PowersModulo
    {
        /// <summary>
        /// 将整数进行二进制展开 
        /// 例如：327 = 256 + 64 + 4 + 2 + 1
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static List<long> BinaryExpansion(long n)
        {
            string binaryN = Convert.ToString(n, 2);
            if (binaryN.IsNullOrEmpty())
                return null;

            List<long> result = new List<long>();
            for (int i = 0; i < binaryN.Length; i++)
            {
                if (binaryN[i] == '0')
                    continue;

                result.Add((long)Math.Pow(2, binaryN.Length - i - 1));
            }

            StringBuilder sb = new StringBuilder();
            foreach (var s in result)
            {
                sb.AppendFormat("{0} + ", s);
            }
            sb.Remove(sb.Length - 3, 3);
            Console.WriteLine("Binary Expansion: {0} = {1}", n.ToString(), sb.ToString());

            return result;
        }

        /// <summary>
        /// 用逐次平方法计算幂模 a^p (mod m)
        /// </summary>
        /// <param name="a"></param>
        /// <param name="p"></param>
        /// <param name="m"></param>
        /// <returns></returns>
        public static long SuccessiveSquaring(long a, long p, long m)
        {
            if (a < 1 || p < 0 || m < 1)
                throw new ArgumentException("Should be a > 0, p >= 0, m > 0");

            var expansion = BinaryExpansion(p);
            expansion.Sort();
            var max = expansion.Last();

            long n = 1;
            long temp = a % m;
            long result = 1;
            while (n <= max)
            {
                if (expansion.Contains(n))
                {
                    Console.WriteLine("{0}^{1} mod {2} = {3}", a, n, m, temp);
                    result = (result * temp) % m;
                }

                n = 2 * n;
                temp = (temp * temp) % m;

            }

            Console.WriteLine("---------------------------------------");
            Console.WriteLine("{0}^{1} mod {2} = {3}", a, p, m, result);
            return result;
        }


        public static void Run()
        {
            SuccessiveSquaring(7, 327, 853);
        }
    }
}
