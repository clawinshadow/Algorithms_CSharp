using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Algorithms.Chapter4;
using NumberTheory;
using NumberTheory.ContinuedFraction;

namespace Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            //Random r = new Random();
            //int[] array = new int[20000];
            //for (int i = 0; i < array.Length; i++)
            //{
            //    array[i] = r.Next(1, 1000000);
            //}

            //using (new OperationTimer("Insertion-Sort"))
            //{
            //    int[] result = Sort.InsertSort(array);
            //}
            //Console.ReadKey();

            //MaximumSubarray.Run();

            //GCD.Run(110, 66);
            
            //ExponentialMod.Run(5, 13, 23);
            //ExponentialMod.Run(28, 749, 1147);

            //double goldenRatio = (1 + Math.Sqrt(5)) / 2;
            //var DA = new Diophantine_Approximation(goldenRatio, 1000);
            //DA.Run();

            //int[] CF2 = new int[] { 3, 2, 1, 2, 1, 2, 1 };
            //int[] CF3 = new int[] { 3, 2, 1, 1, 2, 1, 1, 2, 1, 1 };
            //int[] CF4 = new int[] { 1, 1, 3, 3, 1, 1, 3, 3 };
            //int[] CF5 = new int[] { 3, 1, 1 };
            //int[] CF6 = new int[] { 5, 5, 5, 5 };
            //int[] CF7 = new int[] { 2, 1, 3, 1, 4, 1, 6, 7, 8 };
            //int[] CF8 = new int[] { 3, 1, 4, 5, 6, 4, 5, 6, 4, 5 };
            //int[] CF = new int[] { 3, 2, 5, 2, 1, 4, 2, 5, 2, 1, 4, 2, 5, 2, 1, 4 };
            //PeriodFormat pf = new PeriodFormat(CF8);
            //Console.WriteLine(pf.GetPeriod());
            //Console.ReadKey();

            //_3N_1.Run();

            //Joseph j = new Joseph(5, 2);
            //Console.WriteLine("Calculate Joseph Problem: with 5 people and interval 3");
            //Console.WriteLine(j.Calculate());

            //Prime.Run();
            //Console.WriteLine("a≡∑b");

            //Congruence c = new Congruence(18, 8, 22);
            //Congruence c = new Congruence(893, 266, 2432);
            //c.Run();

            //PowersModulo.Run();
            //CarmichaelNumber.Run(100000);
            Algorithms.Sort.Sample.Run();
            //Console.WriteLine(Math.Log(100000000, 1.11111111));
            //Console.WriteLine(Math.Log(100000000, 2));

            Console.ReadKey();
        }
    }
}
