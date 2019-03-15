using System;
using System.Collections.Generic;

namespace Lab
{
    public static class MyOwnLinq
    {
        public static List<TSource> JoeyWhere<TSource>(this List<TSource> source,
            Func<TSource, bool> conditionFunc)
        {
            var result = new List<TSource>();

            foreach (TSource item in source)
            {
                if (conditionFunc(item))
                {
                    result.Add(item);
                }
            }

            return result;
        }

        public static List<TSource> JoeyWhere<TSource>(this List<TSource> source,
            Func<TSource, int, bool> conditionFunc)
        {
            var result = new List<TSource>();

            foreach (TSource item in source)
            {
                if (conditionFunc(item, source.IndexOf(item)))
                {
                    result.Add(item);
                }
            }

            return result;
        }
    }
}