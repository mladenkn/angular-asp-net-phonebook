using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhoneBook.Models;

namespace PhoneBook.Tests
{
    public static class RandomGenerator
    {
        public static string NextString(this Random rand, int length = 8)
        {
            var rBuilder = new StringBuilder(length);

            for (var i = 0; i < length; i++)
            {
                var randInt = rand.Next(0, 128);
                rBuilder.Append((char) randInt);
            }

            return rBuilder.ToString();
        }

        public static long NextLong(this Random rand) => (long) rand.NextDouble();

        public static List<T> NextList<T>(this Random rand, Func<T> getNext, int length = 8)
        {
            var r = new List<T>();
            for (int i = 0; i < length; i++)
                r.Add(getNext());
            return r;
        }

        public static ContactAllData NextContact(this Random rand) => new ContactAllData
        {
            FirstName = rand.NextString(),
            LastName = rand.NextString(),
            Tags = rand.NextList(() => Guid.NewGuid().ToString()),
            Emails = rand.NextList(() => Guid.NewGuid().ToString()),
            PhoneNumbers = rand.NextList(() => (long) Guid.NewGuid().GetHashCode())
        };
    }
}
