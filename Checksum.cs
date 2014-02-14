using System;
using System.Collections.Generic;
using System.Linq;

namespace Kata_OCR
{
    static class Checksum
    {
        public static bool IsValid(int number)
        {
            /*
             * // F# sample
             * let checksum xs =
             *     xs
             *     |> List.rev
             *     |> List.mapi ((+)1>>(*))
             *     |> List.fold (+) 0
             *     |> flip (%) 11
             *     |> (=)0
             */

            int checksum =
                number.GetDigits()
                      .Selecti((i, d) => (d + 1) * i)
                      .Aggregate(0, (s, d) => d + s);
            return checksum % 11 == 0;
        }
    }

    internal static class Int32Extensions
    {
        /// <summary>
        /// Creates an IEnumerable of digits from an integer.
        /// Eg. 1234 becomes {1,2,3,4}
        /// </summary>
        public static IEnumerable<int> GetDigits(this int number)
        {
            /*
             * let digits n =
             *     let digits n = int (floor (log10 (float n))) + 1
             *     let digitInNumber n i = (n / (pown 10 i)) % 10
             *     [ for i = (digits n)-1 downto 0 do yield digitInNumber n i ]
             */

            for (int i = (int)Math.Floor(Math.Log10(number)); i >= 0; i--)
                yield return (int)(number / Math.Pow(10, i)) % 10;
        }
    }

    internal static class EnumerableExtensions
    {
        public static IEnumerable<TResult> Selecti<TSource, TResult>(this IEnumerable<TSource> enumerable, Func<int, TSource, TResult> selector)
        {
            int i = 0;
            foreach (var item in enumerable)
                yield return selector(i++, item);
        }
    }
}
