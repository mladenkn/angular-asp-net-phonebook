using System.Threading.Tasks;
using PhoneBook.Models;
using PhoneBook.Services;

namespace PhoneBook
{
    public static class DataInitializer
    {
        public static async Task Initialize(IContactsService contactsService)
        {
            var contacts = new[]
            {
                new ContactAllData
                {
                    FirstName = "Mladen",
                    LastName = "Knezović",
                    Emails = new[]
                    {
                        "mladen.knezovic.1993@gmail.com",
                        "mail2@gmail.com"
                    },
                    PhoneNumbers = new[]
                    {
                        4632345345, 4564563234
                    },
                    Tags = new[] {"tag1", "tag2"}
                },

                new ContactAllData
                {
                    FirstName = "Ante",
                    LastName = "Filipović",
                    Emails = new[]
                    {
                        "mail3@gmail.com",
                        "mail4@gmail.com"
                    },
                    PhoneNumbers = new[]
                    {
                        4523462345, 56756734523
                    },
                    Tags = new[] {"tag1", "tag3"}
                }
            };

            foreach (var c in contacts)
                await contactsService.Save(c);
        }
    }
}
