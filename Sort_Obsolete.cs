using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public sealed class Sort_Obsolete
    {
        /// <summary>
        /// 插入排序
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static T[] InsertSort<T>(T[] list) where T : IComparable<T>
        {
            if (list == null || list.Length == 0)
                return list;

            //if (!(typeof(T) == typeof(double) || typeof(T) == typeof(int)))
            //    return list;

            T[] result = new T[list.Length];
            result[list.Length - 1] = list[list.Length - 1];
            if (list.Length == 1)
                return result;

            for (int i = 1; i < list.Length; i++)
            {
                for (int j = 2; j < result.Length; j++)
                {
                    if (list[i].CompareTo(result[j]) > 0)
                    {
                        result[j - 1] = result[j];
                    }
                    else
                    {
                        result[j - 1] = list[i];
                        break;
                    }
                }
            }
            return result;
        }
    }
}
