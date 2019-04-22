using System.Collections.Generic;
using PhoneBook.Abstract;

namespace PhoneBook.Models
{
    public class Contact : IDeletable
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public IEnumerable<ContactTag> Tags { get; set; }
        public IEnumerable<ContactEmail> Emails { get; set; }
        public IEnumerable<ContactPhoneNumber> PhoneNumbers { get; set; }

        public bool IsDeleted { get; set; }
    }

    public class ContactTag
    {
        public int ContactId { get; set; }
        public int TagId { get; set; }
        public Tag Tag { get; set; }
    }

    public class ContactEmail
    {
        public int ContactId { get; set; }
        public string Value { get; set; }
    }

    public class ContactPhoneNumber
    {
        public int ContactId { get; set; }
        public long Value { get; set; }
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
