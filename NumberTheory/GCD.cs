using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberTheory
{
    /// <summary>
    /// 设 a 和 b 是非零整数
    /// 1. 求解最大公因数：g = gcd(a, b).
    /// 2. 求解线性方程 ax + by = g 的通解
    /// </summary>
    public class GCD
    {
        private static long x = 1, v = 0;

        /// <summary>
        /// Calculate GCD of integers: a & b ( 欧几里得算法 )
        /// </summary>
        /// <returns></returns>
        public static long GetGCD(long a, long b)
        {
            if (a <= 0 || b < 0)
                throw new ArgumentException("a or b should not be negative numbers or zero");
            if (a == b)
                return a;

            if (b == 0)
                return a;

            long m = a < b ? b : a;
            long n = a < b ? a : b;

            long p = n;
            long q = m % n;
            return GetGCD(p, q);
        }

        /// <summary>
        /// 求解方程组 ax + by = gcd(a, b) 的通解
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static List<long> GetSolution_LinearAxBy(long a, long b)
        {
            long gcd = GetGCD(a, b);
            Console.WriteLine("GCD is {0}", gcd);
            Console.WriteLine("Get solution of: {0}x + {1}y = {2}", a, b, gcd);
            if (b == 0)
            {
                Console.WriteLine("b should not be zero");
                return null;
            }

            x = 1;
            v = 0;

            long m = a < b ? b : a;
            long n = a < b ? a : b;
            Recursive(m, n);
            long y = (gcd - m * x) / n;

            List<long> result;
            if (a > b)
                result = new List<long> { x, b / gcd, y, a / gcd, gcd };
            else
                result = new List<long> { y, a / gcd, x, b / gcd, gcd };

            return result;
        }


        public static void Recursive(long a, long b)
        {
            long g = a, w = b;   //g, w 作为不停交换a, b的变量

            long q = g / w;  // q是g/w的整数商
            long t = g % w; // t是每一步的余数 g = qw + t 

            long s = x - q * v; // s实际上就是每一步计算完成后当前的x值

            g = w;
            w = t; //这两步是上一步的a,b 和这一步的b, t的交换，将b赋给a, 将余数t赋给b

            x = v;
            v = s; // v是个临时变量，用于计算x的中间步骤

            if (w == 0)
                return;
            else
                Recursive(g, w);
        }


        public static void Run(long a, long b)
        {
            //Console.WriteLine("Calculating GCD of positive integer {0} and {1}...", a, b);
            //int gcd = GetGCD(a, b);
            //Console.WriteLine("GCD is {0}", gcd);

            var result = GetSolution_LinearAxBy(110, 66);

            Console.WriteLine("Solution is : ({0} + {1}k, {2} - {3}k), k is an integer", result[0], result[1], result[2], result[3]);
            Console.ReadKey();

            //Console.ReadKey();
        }

    }
}
