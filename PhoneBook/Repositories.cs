using System.Collections.Generic;
using System.Threading.Tasks;
using PhoneBook.Models;

namespace PhoneBook
{
    public interface IContactRepository
    {
        Task<Contact> GetOne(int contactId);
        Task<Contact> GetDetails(int contactId);
        Task<IEnumerable<ContactListItem>> GetList(GetContactListRequest r);
    }
}
