using System.Collections.Generic;

namespace PhoneBook.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        
        public IEnumerable<ContactEmail> Emails { get; set; }
        public IEnumerable<ContactTag> Tags { get; set; }
        public IEnumerable<ContactPhoneNumber> PhoneNumbers { get; set; }
    }

    public class ContactEmail
    {
        public int ContactId { get; set; }
        public string Email { get; set; }
    }

    public class ContactTag
    {
        public int Id { get; set; }
        public string Tag { get; set; }
    }

    public class ContactPhoneNumber
    {
        public int ContactId { get; set; }
        public long PhoneNumber { get; set; }
    }


    public class ContactDetails
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IEnumerable<string> Emails { get; set; }
        public IEnumerable<string> Tags { get; set; }
        public IEnumerable<long> PhoneNumbers { get; set; }
    }
    
    public class NewContactParams
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IEnumerable<string> Emails { get; set; }
        public IEnumerable<string> Tags { get; set; }
        public IEnumerable<long> PhoneNumbers { get; set; }
    }

    public class ContactListItem
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
