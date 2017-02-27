using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Sort
{
    /// <summary>
    /// 线性时间排序，但是有先决条件，如果知道待排序数组的取值范围是(0, k),且均为整数才适用
    /// 时间复杂度为O(n + k)
    /// 计数排序的局限性在于k的取值范围不能太大，如果是int.MaxValue,那其效率将会非常低下，并且会占用大量的内存空间，因为它不是原址排序的
    /// </summary>
    class CountSort
    {
        public static List<int> Sort(List<int> array, int maxLimit)
        {
            if (array == null || array.Count < 2)
                return array;

            List<int> B = new List<int>(array.Count);     //存放排好序的结果
            List<int> C = new List<int>(maxLimit + 1);    //用于计数，每个索引代表一位数字，范围是[0, k]
            int temp = 0;
            while (temp <= maxLimit)
            { 
                C.Add(0);
                temp++;
            }
            array.ForEach(x => B.Add(0));

            int number;
            for (int i = 0; i < array.Count; i++)
            {
                number = array[i];
                if (number < 0 || number > maxLimit)
                    throw new ArgumentOutOfRangeException(string.Format("number {0} in this array out of range[0, {1}], Sort Aborted!", number, maxLimit));

                C[number] += 1; 
            }

            for (int i = 1; i < C.Count; i++)
            {
                C[i] += C[i - 1];
            }

            int key;
            int index;
            for (int i = array.Count - 1; i >= 0; i--) //逆序循环是为了保证排序的稳定性，即对相同的值，排序之后的顺序与排序之前的一致，make sense for satellite data
            {
                key = array[i];
                index = C[key];

                B[index - 1] = key;
                C[key] -= 1;
            }

            return B;
        }
    }
}
