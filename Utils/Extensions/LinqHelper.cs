using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils.Extensions
{
    public static class LinqHelper
    {
        /// <summary>
        /// 去重
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="source"></param>
        /// <param name="keySelector"></param>
        /// <returns></returns>
        public static IEnumerable<T> DistinctBy<T,TProperty>(this IEnumerable<T> source, Func<T, TProperty> keySelector)
        {
            HashSet<TProperty> hs = new HashSet<TProperty>();
            foreach(var item in source){
                if (hs.Add(keySelector(item)))
                {
                   yield return item;
                }

            }
        }
        /// <summary>
        /// ToList ForEach
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="action"></param>
        public static void  ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            source.ToList().ForEach(action);
        }
    }
}
