using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Sort
{
    class HeapSort
    {
        /// <summary>
        /// HeapSort是原址排序，一般来说常数因子比MergeSort要小一些，比它更快，虽然时间复杂度都是一样的
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static List<int> Sort(List<int> array)
        {
            if (array == null || array.Count < 2)
                return array;

            Build_Max_Heap(array, array.Count);
            for (int i = array.Count - 1; i > 0; i--)
            {
                var temp = array[i];
                array[i] = array[0];
                array[0] = temp;    //构建完最大堆后，数组第一个必定是最大的，将其赋给当前循环的最末尾一个，然后再重新构建最大堆，每次少一个，直至排序完成

                Max_Heapify(array, 0, i);
            }
            return array;
        }

        /// <summary>
        /// 将数组构建成一个最大堆, heapSize不一定等于数组长度，因为在排序最后一步要依次将最大的数剔除出去，即只有一部分数组我们视为堆
        /// </summary>
        /// <param name="array"></param>
        private static void Build_Max_Heap(List<int> array, int heapSize)
        {
            int start = (int)Math.Floor((double)heapSize / 2);//后面一半都是叶子节点，对叶子节点调用MaxHeapify没有任何变化
            for (int i = start; i >= 0; i--)
            {
                Max_Heapify(array, i, heapSize);
            }
        }

        private static void Max_Heapify(List<int> array, int root, int heapSize)
        {
            int largest = root;

            //比较根节点和左右子节点中最大的一个
            int leftIndex = Left(root);
            if (leftIndex < heapSize && array[leftIndex] > array[root])
                largest = leftIndex;

            int rightIndex = Right(root);
            if (rightIndex < heapSize && array[rightIndex] > array[largest])
                largest = rightIndex;

            //将子节点中最大的值与根节点互换，然后递归
            if (largest != root)
            {
                var temp = array[root];
                array[root] = array[largest];
                array[largest] = temp;

                Max_Heapify(array, largest, heapSize);
            }
        }

        /// <summary>
        /// 因为Index是从0开始算的，所以左边的子节点为 2i+1
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        private static int Left(int i)
        {
            return 2 * i + 1;
        }

        private static int Right(int i)
        {
            return 2 * i + 2;
        }
    }
}
