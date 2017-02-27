using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Algorithms.Sort
{
    public class Sample
    {
        private static void Sort(List<int> array, Func<List<int>, List<int>> func)
        {
            Stopwatch sw = new Stopwatch();
            var methodName = string.Format("{0}.{1}()", func.Method.DeclaringType.Name, func.Method.Name);
            Console.WriteLine("{0} starts..", methodName);
            sw.Start();
            var result = func(array);
            sw.Stop();
            Console.WriteLine("{0} ends with time {1}", methodName, sw.ElapsedMilliseconds.ToString());
        }

        private static void CountSortSample(List<int> array, int maxLimit)
        {
            Stopwatch sw = new Stopwatch();
            Console.WriteLine("CountSort.Sort() starts..");
            sw.Start();
            var result = CountSort.Sort(array, maxLimit);
            sw.Stop();
            Console.WriteLine("CountSort.Sort() ends with time {0}", sw.ElapsedMilliseconds.ToString());
        }

        public static void Run()
        {
            var sample1 = Utility.RandomIntegers(20000, 100000);
            var sample2 = sample1.Select(i => i).ToList();  //make a deep copy
            var sample3 = sample1.Select(i => i).ToList();  //make a deep copy
            var sample4 = sample1.Select(i => i).ToList();  //make a deep copy
            var sample5 = sample1.Select(i => i).ToList();  //make a deep copy
            var sample6 = sample1.Select(i => i).ToList();  //make a deep copy
            var sample7 = sample1.Select(i => i).ToList();  //make a deep copy

            Console.WriteLine("----------------Verify Sort Functionality-------------------");
            List<int> demo = new List<int> { 5, 4, 7, 3, 3, 9 };
            var result = InsertionSort.Sort(demo);
            Console.WriteLine("Insertion Sort: {0}", string.Join(",", result.ConvertAll<string>(x => x.ToString())));

            demo = new List<int> { 5, 4, 7, 3, 3, 9 };
            result = BubbleSort.Sort(demo);
            Console.WriteLine("Bubble Sort: {0}", string.Join(",", result.ConvertAll<string>(x => x.ToString())));

            demo = new List<int> { 5, 4, 7, 3, 3, 9 };
            result = MergeSort.Sort(demo);
            Console.WriteLine("Merge Sort: {0}", string.Join(",", result.ConvertAll<string>(x => x.ToString())));

            demo = new List<int> { 5, 4, 7, 3, 3, 9 };
            result = HeapSort.Sort(demo);
            Console.WriteLine("Heap Sort: {0}", string.Join(",", result.ConvertAll<string>(x => x.ToString())));

            demo = new List<int> { 5, 4, 7, 3, 3, 9 };
            result = QuickSort.Sort(demo);
            Console.WriteLine("Quick Sort: {0}", string.Join(",", result.ConvertAll<string>(x => x.ToString())));

            demo = new List<int> { 5, 4, 7, 3, 3, 9 };
            result = CountSort.Sort(demo, 9);
            Console.WriteLine("CountSort Sort: {0}", string.Join(",", result.ConvertAll<string>(x => x.ToString())));

            int selectIndex = 5;
            Console.WriteLine("Select {0}: {1}", selectIndex.ToString(), QuickSort.Randomized_Select(demo, 0, 5, selectIndex));

            Console.WriteLine("----------------Average Time-------------------");
            Sort(sample1, InsertionSort.Sort);
            Sort(sample2, BubbleSort.Sort);
            Sort(sample3, MergeSort.Sort);
            Sort(sample4, HeapSort.Sort);
            Sort(sample5, QuickSort.Sort);
            Sort(sample5, QuickSort.RandomizedSort);
            CountSortSample(sample7, 100000);
            
            Stopwatch sw = new Stopwatch();
            Console.WriteLine("List.Sort() starts..");
            sw.Start();
            sample6.Sort();
            sw.Stop();
            Console.WriteLine("List.Sort() ends with time {0}", sw.ElapsedMilliseconds.ToString()); //Microsoft fastest.

            Console.WriteLine("----------------Best Time-------------------");//an aleady sorted list.
            Sort(sample5, InsertionSort.Sort);
            Sort(sample5, BubbleSort.Sort);
            Sort(sample5, MergeSort.Sort);
            Sort(sample5, HeapSort.Sort);
            //Sort(sample5, QuickSort.Sort);
            Sort(sample5, QuickSort.RandomizedSort);
        }
    }
}
