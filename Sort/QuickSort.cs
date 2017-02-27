using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Sort
{
    public class QuickSort
    {
        private static readonly Random random = new Random();

        public static List<int> Sort(List<int> array)
        {
            if (array == null || array.Count < 2)
                return array;

            Quick_Sort(array, 0, array.Count - 1);
            return array;
        }

        public static List<int> RandomizedSort(List<int> array)
        {
            if (array == null || array.Count < 2)
                return array;

            Quick_Sort_Random(array, 0, array.Count - 1);
            return array;
        }

        /// <summary>
        /// 按顺序排好的数组，对于别的排序方法来说可能是最好的，但是对于QuickSort来说其实是最坏的
        /// 因为每一次递归只比上一次少了一个元素，20000个元素的话要递归19999次，递归是由先入后出的栈来实现的
        /// 但是每个进程的栈空间只有2M，所以递归太深的话栈极容易溢出！
        /// 所以我们一般会给快速排序加一个随机过程，将可能出现的最坏情况也变成期望运行情况
        /// </summary>
        /// <param name="array"></param>
        /// <param name="p"></param>
        /// <param name="r"></param>
        private static void Quick_Sort(List<int> array, int p, int r)
        {
            if (p < r)
            {
                int q = Partition(array, p, r);
                Quick_Sort(array, p, q - 1);
                Quick_Sort(array, q + 1, r);
            }
        }

        /// <summary>
        /// 所以快速排序没有最好情况，只有最坏情况和期望运行情况
        /// </summary>
        /// <param name="array"></param>
        /// <param name="p"></param>
        /// <param name="r"></param>
        private static void Quick_Sort_Random(List<int> array, int p, int r)
        {
            if (p < r)
            {
                //加一个随机过程，避免可能出现的最坏情况
                int q = Randomized_Partition(array, p, r);
                Quick_Sort_Random(array, p, q - 1);
                Quick_Sort_Random(array, q + 1, r);
            }
        }

        /// <summary>
        /// 选择第i个顺序统计量，期望运行时间为O(n)
        /// </summary>
        /// <param name="array"></param>
        /// <param name="p"></param>
        /// <param name="r"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static int Randomized_Select(List<int> array, int p, int r, int i)
        {
            if (p == r)
                return array[p];

            int q = Randomized_Partition(array, p, r);
            if (q == i - 1)
                return array[q];
            if (q > i - 1)
                return Randomized_Select(array, p, q - 1, i);
            else
                return Randomized_Select(array, q + 1, r, i);
        }

        //TODO: 上面的随机化过程也不适用于所有情况，比如当每一个元素都是相同的时候，无论怎么随机化，运行时间一样是n*2，所以需要设计一个三分法来实现完美的快排
        //TODO: 可以继续对随机化过程进行优化，即三数取中划分

        private static int Randomized_Partition(List<int> array, int p, int r)
        {
            int randomIndex = random.Next(p, r);
            var temp = array[randomIndex];
            array[randomIndex] = array[r];
            array[r] = temp;

            return Partition(array, p, r);
        }

        private static int Partition(List<int> array, int p, int r)
        {
            int key = array[r]; //以数组最后一个元素作为主元，以该主元作为分界线，左边的小于它，右边的大于它
            int i = p - 1; // initialize分界线索引
            int temp = 0;
            for (int j = p; j < r; j++)
            {
                if (array[j] <= key)
                {
                    i = i + 1;
                    //exchange (i + 1, j)
                    if (array[i] != array[j])
                    {
                        temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
                }
            }

            temp = array[i + 1];
            array[i + 1] = array[r];
            array[r] = temp;
            return i + 1;
        }
    }
}
