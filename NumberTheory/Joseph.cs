using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberTheory
{
    /// <summary>
    /// 计算约瑟夫问题的解，N为总人数，Q为每隔Q人行刑
    /// </summary>
    public class Joseph
    {
        private int N; //means 所有人为[1,2,3,....,N]的序列
        private int Q; //means 每隔Q人斩首一人

        public Joseph(int n, int q)
        {
            if (n < 1)
                throw new ArgumentException("N should not be non-positive number");
            if (q < 1)
                throw new ArgumentException("Q should not be non-positive number."); 
            N = n;
            Q = q;
        }

        /// <summary>
        /// 计算最后存活的人
        /// </summary>
        /// <returns></returns>
        public int Calculate()
        {
            int D = 1;

            while (D <= 2 * N)
            {
                double value = (D * (Q + 1)) / (double)Q;
                D = (int)Math.Ceiling(value);
            }

            int result = (Q + 1) * N + 1 - D;
            return result;
        }
    }
}
