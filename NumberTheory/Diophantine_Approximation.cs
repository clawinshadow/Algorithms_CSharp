using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberTheory
{
    /// <summary>
    /// Dirichlet's diophantine approximation theorem
    /// 利用狄利克雷的丢番图逼近定理来计算出非常接近无理数 γ 的正整数对(x, y)
    /// </summary>
    public class Diophantine_Approximation
    {
        //无理数 γ
        private readonly double r;
        //正整数对中 y 的最大值, 最后算出的结果中，gap应该小于 1/Power(MAX_Y, 2)
        private readonly int MAX_Y;

        public Diophantine_Approximation(double r, int Y)
        {
            if (Y <= 0)
                throw new ArgumentException("Y should be a positive integer.");

            this.r = r;
            this.MAX_Y = Y;
        }


        public int[] Calculate(int y)
        {
            int[] intPair = new int[2];

            //利用鸽笼原理实现丢番图逼近
            Pigeon[] pigeons = new Pigeon[y + 1];

            //将 Y + 1 个鸽子放入 Y 个鸽笼
            //[0, 1/Y), [1/Y, 2/Y)......[(Y-1)/Y, 1] 
            SortedList<double, List<Pigeon>> cages = new SortedList<double, List<Pigeon>>();

            for (int i = 0; i <= y; i++)
            {
                double value = i * r;
                Pigeon p = new Pigeon();
                p.factor = i;
                p.number = (int)Math.Truncate(value);
                p.fraction = value - p.number;

                pigeons[i] = p;

                if (i > 0)
                {
                    double key = (double)i / y;
                    cages.Add(key, new List<Pigeon>());
                }
            }

            foreach (var pigeon in pigeons)
            {
                var kv = cages.First(c => c.Key > pigeon.fraction && (c.Key - (double)1 / y) <= pigeon.fraction);
                kv.Value.Add(pigeon);

                if (kv.Value.Count == 2)
                {
                    intPair[0] = Math.Abs(kv.Value[0].number - kv.Value[1].number);
                    intPair[1] = Math.Abs(kv.Value[0].factor - kv.Value[1].factor);
                    break;
                }
            }

            return intPair;
        }

        public void Run()
        {
            SortedList<double, int[]> result = new SortedList<double, int[]>();
            Console.WriteLine("Use Dirichlet's diophantine approximation theorem to calculate x/y equals {0} most approximately.", r);

            for (int y = 1; y <= 100000; y++)
            {
                int[] pair = Calculate(y);
                if (pair[1] > MAX_Y)
                {
                    Console.WriteLine("y = {0} exceed the limit {1}! Abort Calculating.", pair[1], MAX_Y);
                    Console.WriteLine("Final Result: ({0}, {1}), Gap is: {2}, less than 1/y*y:{3}", 
                        result.First().Value[0], result.First().Value[1], result.First().Key, (double)1 / Math.Pow(result.First().Value[1], 2));
                    Console.ReadKey();
                    break;
                }
                else
                {
                    double gap = Math.Abs((double)pair[0] / pair[1] - r);
                    if (!result.ContainsKey(gap))
                        result.Add(gap, pair);

                    Console.WriteLine("When y = {0}, most approximately int pair is ({1}, {2}), gap is {3}",
                        y, pair[0], pair[1], gap);
                }
            }
        }
    }

    public struct Pigeon
    {
        //无理数的系数0γ, 1γ, 2γ, 3γ, 4γ ......
        public int factor;

        //0γ = Number + Fraction;
        //浮点数的整数部分
        public int number;

        //浮点数的小数部分
        public double fraction;
    }
}
