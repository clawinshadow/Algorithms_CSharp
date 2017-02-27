using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Sort
{
    /// <summary>
    /// 归并排序，最坏时间n*lgn，但最好时间我估计也差不多是n*lgn，常数因子小点
    /// </summary>
    class MergeSort
    {
        public static List<int> Sort(List<int> array)
        {
            if (array == null || array.Count < 2)
                return array;

            Merge_Sort(array, 0, array.Count - 1);
            return array;
        }

        private static void Merge_Sort(List<int> array, int p, int r)
        {
            if (p < r)
            {
                int q = (int)Math.Floor((double)(p + r) / 2);
                Merge_Sort(array, p, q);
                Merge_Sort(array, q + 1, r);
                Merge(array, p, q, r);
            }
        }

        private static void Merge(List<int> array, int p, int q, int r)
        {
            List<int> sub1 = new List<int>();
            List<int> sub2 = new List<int>();

            for (int i = p; i <= q; i++)
                sub1.Add(array[i]);
            for (int i = q + 1; i <= r; i++)
                sub2.Add(array[i]);

            int count = sub1.Count + sub2.Count;
            List<int> merged = new List<int>();
            while (count > 0)
            {
                if (sub1.Count == 0)
                {
                    merged.AddRange(sub2);
                    break;
                }
                if (sub2.Count == 0)
                {
                    merged.AddRange(sub1);
                    break;
                }

                if (sub1.First() < sub2.First())
                {
                    merged.Add(sub1.First());
                    sub1.RemoveAt(0);
                }
                else
                {
                    merged.Add(sub2.First());
                    sub2.RemoveAt(0);
                }

                count--;
            }

            for (int i = p; i <= r; i++)
            {
                array[i] = merged[i - p];
            }
        }
    }
}
