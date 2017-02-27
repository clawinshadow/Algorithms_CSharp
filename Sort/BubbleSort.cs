using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Sort
{
    /// <summary>
    /// 冒泡排序，最坏n^2, 最好估计也是n^2
    /// </summary>
    public class BubbleSort
    {
        public static List<int> Sort(List<int> array)
        {
            if (array == null || array.Count < 2)
                return array;

            for (int i = 0; i < array.Count - 1; i++)
            {
                for (int j = array.Count - 1; j >= i + 1; j--)
                {
                    if (array[j] < array[j - 1])
                    {
                        var temp = array[j - 1];
                        array[j - 1] = array[j];
                        array[j] = temp;
                    }
                }
            }
            return array; 
        }
    }
}
