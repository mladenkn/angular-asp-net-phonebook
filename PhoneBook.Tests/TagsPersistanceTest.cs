using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhoneBook.DAL;
using PhoneBook.DAL.Abstract;
using PhoneBook.Models;
using PhoneBook.Services;
using Xunit;

namespace PhoneBook.Tests
{
    public class TagsPersistanceTest
    {
        [Fact]
        public async Task Run()
        {
            await Test(
                initialTagValues: new[] { "tag1", "tag2", "tag3" },
                contact: new ContactAllData
                {
                    FirstName = "firstName",
                    LastName = "lastName",
                    Tags = new[] {"tag1", "tag2", "tag4"},
                    Emails = new string[] {},
                    PhoneNumbers = new long[] {}
                },
                expectedPersistedTagValues: new[] {"tag1", "tag2", "tag3", "tag4"}
            );
        }

        public async Task Test(
            IEnumerable<string> initialTagValues, ContactAllData contact, IEnumerable<string> expectedPersistedTagValues)
        {
            var (db, connection) = ServicesFactory.DbContext();
            var unitOfWork = new UnitOfWork(db);
            var mapper = ServicesFactory.MapperConfiguration().CreateMapper();
            var contactDataProvider = new ContactDataProvider(new Query(db), mapper);

            var service = new ContactsService(contactDataProvider, mapper, unitOfWork, null);

            var initialTags = initialTagValues.Select(t => new Tag {Value = t});
            db.Tags.AddRange(initialTags);
            await db.SaveChangesAsync();

            await service.Save(contact);

            var persistedTagValues = db.Tags.ToList().Select(t => t.Value);

            Assert.True(Utilities.CollectionsAreEquivalentOrderIgnored(expectedPersistedTagValues, persistedTagValues));

            connection.Close();
        }
    }
}
