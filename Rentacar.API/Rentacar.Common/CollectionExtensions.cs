using System;
using System.Collections.Generic;
using System.Linq;

namespace Rentacar.Common
{
    public static class CollectionExtensions
    {
        public static double AverageOrEmpty<TSource>(this IEnumerable<TSource> source, Func<TSource, int> selector)
        {
            if (!source.Any())
                return 0;

            return source.Average(selector);
        }
    }
}
