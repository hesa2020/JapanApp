using System;
using System.Collections.Generic;
using System.Linq;

namespace JapanApp
{
    public static class Utility
    {
        private static Random rng = new Random();
        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        public static T RandomOrDefault<T>(this IEnumerable<T> dataSet)
        {
            return dataSet.RandomOrDefault(y => true);
        }

        public static T RandomOrDefault<T>(this IEnumerable<T> dataSet, Func<T, bool> filter)
        {
            var elems = dataSet.Where(filter).ToList();
            var count = elems.Count;
            if (count == 0)
            {
                return default(T);
            }
            var random = new Random();
            var index = random.Next(count - 1);
            return elems[index];
        }

    }
}
