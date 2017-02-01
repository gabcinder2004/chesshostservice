using System;
using System.Collections.Generic;
using System.Linq;

namespace ChessHostService.Services
{
    public static class Utility
    {
        public static int Randomize(int min, int max)
        {
            var random = new Random();
            return random.Next(min, max);
        }

        // Ex: collection.TakeLast(5);
        public static IEnumerable<T> TakeLast<T>(this IEnumerable<T> source, int N)
        {
            return source.Skip(Math.Max(0, source.Count() - N));
        }

        public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            var known = new HashSet<TKey>();
            return source.Where(element => known.Add(keySelector(element)));
        }
    }
}