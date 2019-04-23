using System.Threading.Tasks;
using KellermanSoftware.CompareNetObjects;
using PhoneBook.DAL;
using PhoneBook.DAL.Abstract;
using PhoneBook.Models;
using PhoneBook.Services;
using Xunit;

namespace PhoneBook.Tests
{
    public class ContactPersistenceTest
    {
        [Fact]
        public async Task Run()
        {
            await Test(new ContactAllData
            {
                FirstName = "firstName",
                LastName = "lastName",
                Tags = new[] { "tag1", "tag2", "tag3" },
                Emails = new[] { "mail1", "mail2", "mail3" },
                PhoneNumbers = new long[] { 1, 2, 3 }
            });
        }

        private async Task Test(ContactAllData contact)
        {
            var (db, connection) = ServicesFactory.DbContext();
            var unitOfWork = new UnitOfWork(db);
            var mapper = ServicesFactory.MapperConfiguration().CreateMapper();
            var query = new Query(db);
            var contactDataProvider = new ContactDataProvider(query, mapper);
            var dataProvider = new DataProvider(query);
            var appService = new AppService(dataProvider);

            var service = new ContactsService(contactDataProvider, mapper, unitOfWork, appService);
            await service.Save(contact);

            var readContact = await service.GetAllContactData(contact.Id);
            Assert.NotNull(readContact);

            var comparer = new CompareLogic();
            comparer.Config.IgnoreObjectTypes = true;
            var compareResult = comparer.Compare(contact, readContact);
            Assert.True(compareResult.AreEqual);

            connection.Close();
        }
    }
}
