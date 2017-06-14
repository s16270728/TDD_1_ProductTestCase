using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatisticsLib
{
    public class Statistics
    {
        /// <summary>
        /// 將傳入的物件取其中的屬性依據數量分組加總
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="groupSize">幾筆資料為一組</param>
        /// <param name="target">目標物件</param>
        /// <param name="selector">目標物件做加總的屬性</param>
        /// <returns></returns>
        public IEnumerable<int> GroupSum<TSource>(int groupSize,List<TSource> target, Func<TSource, int> selector)
        {
            //groupSize 不可小於0
            if(groupSize < 1)
            {
                throw new ArgumentException();
            }
            //groupSize = 0 return 0
            //else if(groupSize == 0)
            //{
            //    yield return 0;
            //}
            //根據groupSize及selector做加總運算
            else
            {
                var index = 0;
                while (index <= target.Count)
                {
                    yield return target.Skip(index).Take(groupSize).Sum(selector);
                    index += groupSize;
                }
            }
        }
    }
}
