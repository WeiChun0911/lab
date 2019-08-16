using System;
using System.Collections.Generic;

namespace Lab
{
    public static class ExtensionMethod
    {
        public static List<TSource> JoeyWhere<TSource>(this List<TSource> source, Func<TSource, bool> predicate)
        {
            var result = new List<TSource>();
            foreach (var item in source)
            {
                if (predicate(item))
                {
                    result.Add(item);
                }
            }

            return result;
        }

        public static List<int> JoeyWhereWithIndex(List<int> numbers, Func<int, int, bool> predicate)
        {
            var list = new List<int>();
            int index = 0;
            foreach (var number in numbers)
            {
                if (predicate(number, index))
                {
                    list.Add(number);
                }

                index++;
            }

            return list;
        }
    }
}