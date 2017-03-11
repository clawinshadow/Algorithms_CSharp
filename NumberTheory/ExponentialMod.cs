using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberTheory
{
    //用逐次平方法的优化版来求高次幂模 m
    public class ExponentialMod
    {
        //求形如Power(a, k) mod m
        public static int GetExponentialMod(int a, int k, int m)
        {
            if (k < 0)
                throw new ArgumentException("exponent k should not be negative.");

            int b = 1;
            while (k >= 1)
            {
                if (k % 2 == 1)
                {
                    b = (b * a) % m;
                    k--;
                }
                else
                {
                    a = (int)Math.Pow(a, 2) % m;
                    k = k / 2;
                }
            }
            return b;
        }

        public static void Run(int a, int k, int m)
        {
            Console.WriteLine("Calculating Exponential Mod -> a: {0}, k: {1}, m: {2}", a, k, m);
            Console.WriteLine("result is: " + GetExponentialMod(a, k, m));
            Console.ReadKey();
        }
    }
}
