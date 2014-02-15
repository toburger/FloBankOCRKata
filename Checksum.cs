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
             *     |> List.sum
             *     |> flip (%) 11
             *     |> (=)0
             */

            int checksum =
                number.GetDigits()
                      .Reverse()
                      .Selecti((i, d) => (i + 1) * d)
                      .Sum();
            return checksum % 11 == 0;
        }
    }
}
