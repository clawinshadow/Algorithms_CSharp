using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Sort
{
    /// <summary>
    /// 插入排序，最坏时间: n^2, 最好时间n, 平均时间n^2
    /// </summary>
    public class InsertionSort
    {
        public static List<int> Sort(List<int> array)
        {
            if (array == null || array.Count < 2)
                return array;

            for (int i = 1; i < array.Count; i++)
            {
                int key = array[i];

                int j = i - 1;
                while (j >= 0 && array[j] > key)
                {
                    array[j + 1] = array[j];
                    j--;
                }

                array[j + 1] = key;
            }
            return array; 
        }
    }
}
