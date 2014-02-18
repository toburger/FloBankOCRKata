using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata_OCR.Library
{
    internal static class Int32Extensions
    {
        /// <summary>
        /// Creates an IEnumerable of digits from an integer.
        /// Eg. 1234 becomes {1,2,3,4}
        /// </summary>
        public static IEnumerable<int> GetDigits(this int number)
        {
            for (int i = (int)Math.Floor(Math.Log10(number)); i >= 0; i--)
                yield return (int)(number / Math.Pow(10, i)) % 10;
        }
    }

    internal static class EnumerableExtensions
    {
        public static IEnumerable<TResult> Selecti<TSource, TResult>(
            this IEnumerable<TSource> enumerable,
            int seed,
            Func<int, TSource, TResult> selector)
        {
            foreach (var item in enumerable)
                yield return selector(seed++, item);
        }

        public static IEnumerable<TResult> Selecti<TSource, TResult>(
            this IEnumerable<TSource> enumerable,
            Func<int, TSource, TResult> selector)
        {
            return Selecti(enumerable, 0, selector);
        }

        public static void Iter<TSource>(
            this IEnumerable<TSource> enumerable,
            Action<TSource> action)
        {
            foreach (var item in enumerable)
                action(item);
        }

        public static void Iteri<TSource>(
            this IEnumerable<TSource> enumerable,
            int seed,
            Action<int, TSource> action)
        {
            foreach (var item in enumerable)
                action(seed++, item);
        }

        public static void Iteri<TSource>(
            this IEnumerable<TSource> enumerable,
            Action<int, TSource> action)
        {
            Iteri(enumerable, 0, action);
        }
    }
}
