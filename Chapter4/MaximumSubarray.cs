using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Chapter4
{
    public class MaximumSubarray
    {
        private static Random r = new Random();

        public static MaximumSubarrayResult Find_Max_Crossing_Subarray(int[] array, int low, int mid, int high)
        {
            if (array == null || array.Length == 0 || low > high || low > mid || mid > high)
                return null;

            var result = new MaximumSubarrayResult();
            int left_sum = int.MinValue, right_sum = int.MinValue;
            int sum = 0;
            for (int i = mid; i >= low; i--)
            {
                sum += array[i];
                if (sum > left_sum)
                {
                    left_sum = sum;
                    result.max_left = i;
                }
            }

            sum = 0;
            for (int j = mid + 1; j <= high; j++)
            {
                sum += array[j];
                if (sum > right_sum)
                {
                    right_sum = sum;
                    result.max_right = j;
                }
            }

            result.max_sum = left_sum + right_sum;
            return result;
        }

        // (nlgn)
        public static MaximumSubarrayResult Find_Maximum_Subarray(int[] array, int low, int high)
        {
            var result = new MaximumSubarrayResult();
            if (low == high)
            {
                result.max_left = low;
                result.max_right = high;
                result.max_sum = array[low];
                return result;
            }
            else
            {
                int mid = Convert.ToInt32(Math.Floor((low + high) / 2.0d));

                var leftResult = Find_Maximum_Subarray(array, low, mid);
                var rightResult = Find_Maximum_Subarray(array, mid + 1, high);
                var crossResult = Find_Max_Crossing_Subarray(array, low, mid, high);
                if (leftResult.max_sum >= rightResult.max_sum && leftResult.max_sum >= crossResult.max_sum)
                    return leftResult;
                if (rightResult.max_sum >= leftResult.max_sum && rightResult.max_sum >= crossResult.max_sum)
                    return rightResult;
                return crossResult;
            }
        }

        //暴力解法
        public static MaximumSubarrayResult Find_Maximum_Subarray_Violent(int[] array, int low, int high)
        {
            var result = new MaximumSubarrayResult();
            result.max_sum = int.MinValue;

            int sum = 0;
            for (int i = low; i <= high; i++)
            {
                for (int j = high; j >= i; j--)
                {
                    sum = 0;
                    for (int k = i; k <= j; k++)
                    {
                        sum += array[k];
                    }
                    if (sum > result.max_sum)
                    {
                        result.max_sum = sum;
                        result.max_left = i;
                        result.max_right = j;
                    }
                }
            }

            return result;
        }

        public static void Run()
        {
            int[] array = new int[3000];
            for (int i = 0; i < array.Length; i++)
                array[i] = r.Next(-1000, 1000);

            //int[] array = new int[] { 2, 1, -3, 4, -1, 5, 12, -4, 10 };

            using (new OperationTimer("Maximum-Subarray"))
            {
                var result = Find_Maximum_Subarray(array, 0, array.Length - 1);
                Console.WriteLine("Max-Left: {0} \n Max_Right: {1} \n Max_Sum: {2}", 
                    array[result.max_left], array[result.max_right], result.max_sum);
            }

            using (new OperationTimer("Maximum-Subarray-Violent"))
            {
                var result = Find_Maximum_Subarray_Violent(array, 0, array.Length - 1);
                Console.WriteLine("Max-Left: {0} \n Max_Right: {1} \n Max_Sum: {2}",
                                    array[result.max_left], array[result.max_right], result.max_sum);
            }

            Console.ReadKey();
        }

    }
}
