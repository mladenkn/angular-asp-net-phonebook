using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Tests
{
    public static class Utilities
    {
        public static bool JustOne<T>(this IEnumerable<T> enumerable, Func<T, bool> filter)
        {
            var count = enumerable.Count(filter);
            return count == 1;
        }

        public static bool CollectionsAreEquivalentOrderIgnored<T>(IEnumerable<T> enumerable1, IEnumerable<T> enumerable2)
        {
            return Enumerable.SequenceEqual(enumerable1.OrderBy(e => e), enumerable2.OrderBy(e => e));
        }
    }
}
