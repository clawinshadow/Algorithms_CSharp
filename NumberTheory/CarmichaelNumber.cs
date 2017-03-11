using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace NumberTheory
{
    /// <summary>
    /// 卡米歇尔数的考塞特判别法，
    /// 1. N的素数乘积中，每一个素数的幂次不超过1
    /// 2. 每一个素因子 p 都有： (p - 1) | (N - 1)
    /// 3. N是奇数
    /// </summary>
    public class CarmichaelNumber
    {
        public static bool KorseltCriterion(long n)
        {
            if (!Utility.IsOdd(n))
                return false;

            var divisors = Prime.SplitDivisor(n);
            if (divisors.IsNullOrEmpty() || divisors.Count == 1)
                return false;

            long temp = n - 1;
            foreach (var kv in divisors)
            {
                if (kv.Value > 1)
                    return false;

                if (temp % (kv.Key - 1) != 0)
                    return false;
            }

            return true;
        }

        /// <summary>
        /// 求max以内的卡米歇尔数
        /// </summary>
        public static void Run(long max)
        {
            for (long i = 2; i <= max; i++)
            {
                if (KorseltCriterion(i))
                {
                    Console.WriteLine("Carmichael Number: {0}", i.ToString());
                }
            }

        }
    }
}
