using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PhoneBook.Abstract;
using PhoneBook.Models;

namespace PhoneBook
{
    public interface IContactDataProvider
    {
        Task<Contact> GetOne(int contactId, Action<IncludesBuilder<Contact>> include = null);
        Task<ContactAllData> GetAllContactData(int contactId);
        Task<IEnumerable<ContactListItem>> GetList(GetContactListRequest r);
    }
}
