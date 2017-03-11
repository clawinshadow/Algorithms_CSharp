using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberTheory
{
    /// <summary>
    /// 求解同余式 ax≡c(mod m) 的不同解 
    /// </summary>
    public class Congruence
    {
        private long _a, _c, _m;

        public Congruence(long a, long c, long m)
        {
            if (a < 1 || c < 1 || m < 1)
                throw new ArgumentException("a, c, m should all be positive integers");

            _a = a;
            _c = c;
            _m = m;
        }

        public List<long> GetSolution()
        {
            long gcd = GCD.GetGCD(_a, _m);
            if (_c % gcd != 0)
            {
                Console.WriteLine("gcd(a, m) can't divide c, this congruence has no solution.");
                return null;
            }

            var solution = GCD.GetSolution_LinearAxBy(_a, _m);
            if (solution == null)
            {
                Console.WriteLine("Solution of ax + my = gcd(a, m) is null.");
                return null;
            }

            long factor = _c / gcd;
            long u0 = solution[0];

            long x0 = factor * u0;
            long factor2 = _m / gcd;
            List<long> result = new List<long>();

            for (int i = 0; i < gcd; i++)
            {
                var temp = x0 + i * factor2;
                if (temp >= _m)
                    temp = temp % _m;
                if (temp < 0)
                    temp = _m - Math.Abs(temp) % _m;

                result.Add(temp);
            }

            return result;
        }

        public void Run()
        {
            Console.WriteLine("Calculating the solution of congruence: {0}x ≡ {1} (mod {2})...", _a, _c, _m);
            var result = GetSolution();
            if (result != null)
            {
                Console.WriteLine("There are {0} different solutions:", result.Count);

                result.Sort();
                foreach (var x in result)
                    Console.WriteLine("x = {0}", x);
            }

            Console.ReadKey();
        }
    }
}
