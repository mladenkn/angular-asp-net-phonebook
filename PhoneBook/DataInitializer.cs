using System.Linq;
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
                new Contact
                {
                    FirstName = "Mladen",
                    LastName = "Knezović",
                    Emails = new[]
                    {
                        new Contact.Email { Value = "mladen.knezovic.1993@gmail.com"},
                        new Contact.Email { Value = "mail2@gmail.com"},
                    },
                    PhoneNumbers = new[]
                    {
                        new Contact.PhoneNumber { Value = 4632345345},
                        new Contact.PhoneNumber { Value = 4564563234},
                    },
                    Tags = new[]
                    {
                        new Contact.Tag { Value = "tag1"},
                        new Contact.Tag { Value = "tag2"},
                    }
                },

                new Contact
                {
                    FirstName = "Ante",
                    LastName = "Filipović",
                    Emails = new[]
                    {
                        new Contact.Email { Value = "mail3@gmail.com"},
                        new Contact.Email { Value = "mail4@gmail.com"},
                    },
                    PhoneNumbers = new[]
                    {
                        new Contact.PhoneNumber { Value = 4523462345},
                        new Contact.PhoneNumber { Value = 56756734523},
                    },
                    Tags = new[]
                    {
                        new Contact.Tag { Value = "tag1"},
                        new Contact.Tag { Value = "tag3"},
                    }
                },

                new Contact
                {
                    FirstName = "Ime1",
                    LastName = "Prezime1",
                    Emails = new[]
                    {
                        new Contact.Email { Value = "mail4@gmail.com"},
                    },
                    PhoneNumbers = new[]
                    {
                        new Contact.PhoneNumber { Value = 34545673456},
                    },
                    Tags = new[]
                    {
                        new Contact.Tag { Value = "tag1"},
                        new Contact.Tag { Value = "tag3"},
                        new Contact.Tag { Value = "tag4"},
                    }
                },

                new Contact
                {
                    FirstName = "Ime2",
                    LastName = "Prezime2",
                    Emails = new[]
                    {
                        new Contact.Email { Value = "mail4@gmail.com"},
                    },
                    PhoneNumbers = new[]
                    {
                        new Contact.PhoneNumber { Value = 34545673456},
                    },
                    Tags = new[]
                    {
                        new Contact.Tag { Value = "tag1"},
                        new Contact.Tag { Value = "tag3"},
                        new Contact.Tag { Value = "tag5"},
                    }
                },
            };

            foreach (var c in contacts)
                await contactsService.Save(c);
        }
    }
}
