using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kingmaker;
internal static class ArrayExtensions
{
    public static string ToCommaSeparatedString<T>(this IEnumerable<T> array)
    {
        return string.Join(", ", array);
    }
}
