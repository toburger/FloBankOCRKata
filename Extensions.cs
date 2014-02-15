using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata_OCR
{
    public static class Int32Extensions
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

    public static class EnumerableExtensions
    {
        public static IEnumerable<TResult> Selecti<TSource, TResult>(
            this IEnumerable<TSource> enumerable,
            Func<int, TSource, TResult> selector)
        {
            int i = 0;
            foreach (var item in enumerable)
                yield return selector(i++, item);
        }
    }
}
