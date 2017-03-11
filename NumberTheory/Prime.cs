using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace NumberTheory
{
    /// <summary>
    /// 包含常用的素数方法
    /// </summary>
    public static class Prime
    {
        public static bool IsPrime(long integer, out long factor)
        {
            factor = 1;
            long square = (long)Math.Ceiling(Math.Sqrt(integer));

            for (long i = 2; i <= square; i++)
            {
                long divisor = integer % i;
                if (divisor == 0)
                {
                    factor = i;
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// 将一个整数分解成唯一的素数乘积，Key为因数，Value为指数
        /// </summary>
        /// <param name="integer"></param>
        /// <returns></returns>
        public static Dictionary<long, int> SplitDivisor(long integer)
        {
            if (integer <= 0)
                throw new ArgumentException("integer should be positive");

            Dictionary<long, int> result = new Dictionary<long, int>();

            SplitDivisor_Recurrence(integer, result);

            result.Remove(1);
            return result;
        }

        private static void SplitDivisor_Recurrence(long integer, Dictionary<long, int> divisors)
        {
            if (divisors == null)
                divisors = new Dictionary<long, int>();

            long divisor;
            if (IsPrime(integer, out divisor))
            {
                TryAdd(divisors, integer);
                return;
            }
            else
            {
                TryAdd(divisors, divisor);
                SplitDivisor_Recurrence(integer / divisor, divisors);
            }
        }

        private static void TryAdd(Dictionary<long, int> dict, long key)
        {
            if (dict.ContainsKey(key))
                dict[key]++;
            else
                dict.Add(key, 1);
        }

        public static void Run()
        {
            //for (int i = 1000000; i < 1003001; i++)
            //{
            //    var result = Prime.SplitDivisor(i);

            //    StringBuilder sb = new StringBuilder();
            //    foreach (var kv in result)
            //    {
            //        if (kv.Value == 1)
            //            sb.Append(kv.Key.ToString());
            //        else
            //            sb.Append(string.Format("{0}^{1}", kv.Key.ToString(), kv.Value.ToString()));

            //        sb.Append(" * ");
            //    }

            //    Console.WriteLine("Split divisors: {0} = {1}", i, sb.ToString().TrimEnd(new char[] { '*', ' ' }));
            //}

            for (int i = 1; i < 11; i++)
            {
                List<long> relativePrimes;
                var count = GetRelativelyPrimeCount(i, out relativePrimes);

                StringBuilder sb = new StringBuilder();
                sb.AppendFormat("Φ({0}) = {1} : [", i, count);
                foreach (var n in relativePrimes)
                {
                    sb.Append(n.ToString());
                    sb.Append(", ");
                }
                sb.Remove(sb.Length - 2, 2);
                sb.Append("]");
                Console.WriteLine(sb.ToString());
            }
        }

        /// <summary>
        /// 计算欧拉函数Φ(m), 即0与m之间与m互素的整数个数
        /// </summary>
        /// <param name="number"></param>
        /// <param name="relativePrimes"></param>
        /// <returns></returns>
        public static long GetRelativelyPrimeCount(long number, out List<long> relativePrimes)
        {
            relativePrimes = new List<long>();
            if (number < 1)
                throw new ArgumentException("Number should be positive integers.");

            for (long i = 1; i <= number; i++)
            {
                var gcd = GCD.GetGCD(i, number);
                if (gcd == 1)
                    relativePrimes.Add(i);
            }

            return relativePrimes.Count;
        }
    }
}
