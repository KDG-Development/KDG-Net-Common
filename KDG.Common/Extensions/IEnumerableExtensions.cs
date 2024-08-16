using System.Collections.Generic;
using KDG.Common.Tuples;


namespace KDG.Common.Extensions
{
    public static class IEnumerableExtensions
    {
        public static PassFail<List<T>> ApplyFilter<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            var pass = new List<T>();
            var fail = new List<T>();

            foreach (var item in source)
            {
                if (predicate(item))
                    pass.Add(item);
                else
                    fail.Add(item);
            }

            return new PassFail<List<T>>(pass, fail);
        }
    }
}
