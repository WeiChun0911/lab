using System;
using System.Collections.Generic;

namespace Lab
{
    public static class ExtensionMethod
    {
        public static IEnumerable<TSource> JoeyWhere<TSource>(this List<TSource> source, Func<TSource, bool> predicate)
        {
            var enumerator = source.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var item = enumerator.Current;
                if (predicate(item))
                {
                    yield return item;
                }
            }
            //foreach (var item in source)
            //{
            //    if (predicate(item))
            //    {
            //        result.Add(item);
            //    }
            //}

            //return result;
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

        public static List<TResult> JoeySelect<TSource, TResult>(this List<TSource> employees, Func<TSource, TResult> selector)
        {
            var list = new List<TResult>();
            foreach (var employee in employees)
            {
                list.Add(selector(employee));
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
        
        public static IEnumerable<TResult> JoeySelect<TSource, TResult>(this IEnumerable<TSource> source,
            Func<TSource, int, TResult> selector)
        {
            var result = new List<TResult>();
            var index = 0;
            foreach (var url in source)
            {
                result.Add(selector(url, index));
                index++;
            }

            return result;
        }

        public static IEnumerable<TResult> JoeySelect<TSource, TResult>(this IEnumerable<TSource> source,
            Func<TSource, TResult> selector)
        {
            var enumerator = source.GetEnumerator();
            while (enumerator.MoveNext())
            {
                yield return selector(enumerator.Current);
            }

            //var result = new List<TResult>();
            //foreach (var item in source)
            //{
            //    result.Add(selector(item));
            //}

            //return result;
        }

        public static IEnumerable<TSource> JoeyWhere<TSource>(this IEnumerable<TSource> source,
            Func<TSource, bool> predicate)
        {
            var enumerator = source.GetEnumerator();
            //var result = new List<TSource>();
            while (enumerator.MoveNext())
            {
                var item = enumerator.Current;

                if (predicate(item))
                {
                    //result.Add(item);
                    yield return item;
                }
            }

            //foreach (var item in source)
            //{
            //    if (predicate(item))
            //    {
            //        result.Add(item);
            //    }
            //}

            //return result;
        }

        public static List<TSource> JoeyWhere<TSource>(this IEnumerable<TSource> numbers,
            Func<TSource, int, bool> predicate)
        {
            var index = 0;
            var result = new List<TSource>();
            foreach (var number in numbers)
            {
                if (predicate(number, index))
                {
                    result.Add(number);
                }

                index++;
            }

            return result;
        }

        public static bool JoeyAnyWithCondition(this IEnumerable<int> source, Func<int, bool> predicate)
        {
            var enumerator = source.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var current = enumerator.Current;
                if (predicate(current))
                {
                    return true;
                }
            }

            return false;
        }
    }
}