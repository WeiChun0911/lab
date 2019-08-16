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

        public static List<TSource> JoeyWhereWithIndex<TSource>(List<TSource> numbers, Func<TSource, int, bool> predicate)
        {
            var list = new List<TSource>();
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

        public static List<string> JoeySelectWithIndex(this IEnumerable<string> urls, Func<int, string, string> Selector)
        {
            var list = new List<string>();
            var index = 0;
            foreach (var url in urls)
            {
                list.Add(Selector(index, url));
                index++;
            }
            return list;
        }

        public static IEnumerable<string> JoeySelect(this IEnumerable<string> urls, Func<string, string> Selector)
        {
            var list = new List<string>();
            foreach (var url in urls)
            {
                list.Add(Selector(url));
            }
            return list;
        }
    }
}