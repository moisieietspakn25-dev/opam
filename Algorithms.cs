using System;
using System.Collections.Generic;

namespace OpamLab07
{
    public static class Algorithms
    {
        // Завдання 1. Відбір
        public static List<T> Filter<T>(
            List<T> src,
            Func<T, bool> keep)
        {
            List<T> result = new List<T>();

            foreach (T item in src)
            {
                if (keep(item))
                    result.Add(item);
            }

            return result;
        }

        // Завдання 2. Перетворення
        public static List<TOut> Map<TIn, TOut>(
            List<TIn> src,
            Func<TIn, TOut> convert)
        {
            List<TOut> result = new List<TOut>();

            foreach (TIn item in src)
            {
                result.Add(convert(item));
            }

            return result;
        }

        // Завдання 3. Агрегація
        public static TAcc Aggregate<T, TAcc>(
            List<T> src,
            TAcc start,
            Func<TAcc, T, TAcc> step)
        {
            TAcc accumulator = start;

            foreach (T item in src)
            {
                accumulator = step(accumulator, item);
            }

            return accumulator;
        }

        // Завдання 4. Групування
        public static Dictionary<TKey, List<T>> GroupBy<T, TKey>(
            List<T> src,
            Func<T, TKey> keyOf) where TKey : notnull
        {
            Dictionary<TKey, List<T>> result =
                new Dictionary<TKey, List<T>>();

            foreach (T item in src)
            {
                TKey key = keyOf(item);

                if (!result.ContainsKey(key))
                    result[key] = new List<T>();

                result[key].Add(item);
            }

            return result;
        }
    }
}