using System.Collections.Generic;
namespace PhoneBook.Models
{
    public class Contact : IDeletable
    {
        public class Email
        {
            public int Id { get; set; }
            public int ContactId { get; set; }
            public string Value { get; set; }
        }

        public class Tag
        {
            public int Id { get; set; }
            public int ContactId { get; set; }
            public string Value { get; set; }
        }

        public class PhoneNumber
        {
            public int Id { get; set; }
            public int ContactId { get; set; }
            public long Value { get; set; }
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public IEnumerable<Tag> Tags { get; set; }
        public IEnumerable<Email> Emails { get; set; }
        public IEnumerable<PhoneNumber> PhoneNumbers { get; set; }

        public bool IsDeleted { get; set; }
    }

    public class ContactListItem
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IEnumerable<string> Tags { get; set; }
    }

    public class ContactAllData
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IEnumerable<string> Tags { get; set; }
        public IEnumerable<string> Emails { get; set; }
        public IEnumerable<long> PhoneNumbers { get; set; }
    }
}
