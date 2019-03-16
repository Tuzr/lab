using System;
using System.Collections.Generic;

namespace Lab
{
    public static class MyOwnLinq
    {
        public static IEnumerable<TSource> JoeyWhere<TSource>(this IEnumerable<TSource> source,
            Func<TSource, bool> conditionFunc)
        {
            var sourceEnumerator = source.GetEnumerator();

            while (sourceEnumerator.MoveNext())
            {
                var item = sourceEnumerator.Current;
                if (conditionFunc(item))
                {
                    yield return item;
                }
            }


            //foreach (TSource item in source)
            //{
            //    if (conditionFunc(item))
            //    {
            //        yield return item;
            //    }
            //}
        }

        public static IEnumerable<TSource> JoeyWhere<TSource>(this IEnumerable<TSource> source,
            Func<TSource, int, bool> conditionFunc)
        {
            int index=0;

            foreach (TSource item in source)
            {
                if (conditionFunc(item, index))
                {
                    //result.Add(item);
                    yield return item;
                    index++;
                }
            }

        }

        public static IEnumerable<TResult> JoeySelectWithAppend<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, int, TResult> selector)
        {
            List<TResult> resultList = new List<TResult>();

            int index = 0;

            foreach (var item in source)
            {
                resultList.Add(selector(item, index));
                index++;
            }

            return resultList;
        }

        public static IEnumerable<TResult> JoeySelect<TSource, TResult>(IEnumerable<TSource> source, Func<TSource, TResult> selector)
        {
            //List<TResult> resultList = new List<TResult>();

            foreach (var item in source)
            {
                //resultList.Add(selector(item));
                yield return selector(item);
            }

            //return resultList;
        }


        public static TSource JoeyFirstOrDefault<TSource>(this IEnumerable<TSource> sources)
        {
            var employeeEnumerator = sources.GetEnumerator();

            //while (employeeEnumerator.MoveNext())
            //{
            //    if (employeeEnumerator.Current != null)
            //    {
            //        return employeeEnumerator.Current;
            //    }
            //}
            //return default(TSource);

            return employeeEnumerator.MoveNext() ? employeeEnumerator.Current : default(TSource);

        }
    }
}