//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using PhoneBook.DAL;
//using PhoneBook.DAL.Abstract;
//using PhoneBook.Models;
//using PhoneBook.Services;
//using Xunit;

//namespace PhoneBook.Tests
//{
//    public class TagsPersistenceTest
//    {
//        public IEnumerable<object[]> SaveData => new List<object[]>
//        {
//            new object[]
//            {
//                new string[] {},
//                new ContactAllData
//                {
//                    FirstName = "firstName",
//                    LastName = "lastName",
//                    Tags = new[] {"tag1", "tag2", "tag3"},
//                    Emails = new string[] { },
//                    PhoneNumbers = new long[] { }
//                },
//                new[] {"tag1", "tag2", "tag3"},
//            },
//            new object[]
//            {
//                new [] {"tag1", "tag2", "tag3"},
//                new ContactAllData
//                {
//                    FirstName = "firstName",
//                    LastName = "lastName",
//                    Tags = new[] {"tag1", "tag2", "tag4"},
//                    Emails = new string[] { },
//                    PhoneNumbers = new long[] { }
//                },
//                new[] {"tag1", "tag2", "tag3", "tag4"}
//            }
//        }

//        [Theory]
//        [MemberData(nameof(SaveData))]
//        public async Task Save(
//            IEnumerable<string> initialTagValues, ContactAllData contact, IEnumerable<string> expectedPersistedTagValues)
//        {
//            var (db, connection) = ServicesFactory.DbContext();
//            var unitOfWork = new UnitOfWork(db);
//            var mapper = ServicesFactory.MapperConfiguration().CreateMapper();
//            var query = new Query(db);
//            var contactDataProvider = new ContactDataProvider(query, mapper);
//            var dataProvider = new DataProvider(query);
//            var appService = new AppService(dataProvider);

//            var service = new ContactsService(contactDataProvider, mapper, unitOfWork, appService);

//            var initialTags = initialTagValues.Select(t => new Tag { Value = t });
//            db.Tags.SaveRange(initialTags);
//            await db.SaveChangesAsync();

//            await service.Save(contact);

//            var persistedTagValues = db.Tags.ToList().Select(t => t.Value);
//            Assert.True(Utilities.CollectionsAreEquivalentOrderIgnored(expectedPersistedTagValues, persistedTagValues));

//            connection.Close();
//        }

        //[Fact]
        //public async Task RunUpdate()
        //{
        //    await TestUpdate(
        //        initialContact: new ContactAllData
        //        {
        //            FirstName = "firstName",
        //            LastName = "lastName",
        //            Tags = new[] {"tag1", "tag2", "tag4"},
        //            Emails = new string[] { },
        //            PhoneNumbers = new long[] { }
        //        },
        //        contactOnUpdate: new ContactAllData
        //        {
        //            FirstName = "firstName",
        //            LastName = "lastName",
        //            Tags = new[] {"tag1", "tag5"},
        //            Emails = new string[] { },
        //            PhoneNumbers = new long[] { }
        //        },
        //        expectedPersistedTagValues: new[] {"tag1", "tag2", "tag3", "tag4", "tag5"}
        //    );
        //}

        //public async Task TestUpdate(
        //    ContactAllData initialContact, ContactAllData contactOnUpdate, IEnumerable<string> expectedPersistedTagValues)
        //{
        //    var (db, connection) = ServicesFactory.DbContext();
        //    var unitOfWork = new UnitOfWork(db);
        //    var mapper = ServicesFactory.MapperConfiguration().CreateMapper();
        //    var query = new Query(db);
        //    var contactDataProvider = new ContactDataProvider(query, mapper);
        //    var dataProvider = new DataProvider(query);
        //    var appService = new AppService(dataProvider);
        //    var service = new ContactsService(contactDataProvider, mapper, unitOfWork, appService);
            
        //    await service.Update(contactOnUpdate);

        //    var persistedTagValues = db.Tags.ToList().Select(t => t.Value);
        //    Assert.True(Utilities.CollectionsAreEquivalentOrderIgnored(expectedPersistedTagValues, persistedTagValues));

        //    connection.Close();
        //}
//    }
//}
