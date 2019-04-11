using System.Collections.Generic;
using System.Threading.Tasks;
using PhoneBook.Models;

namespace PhoneBook
{
    public interface IContactRepository
    {
        Task<ContactDetails> GetDetails(int contactId);
        Task<IEnumerable<ContactListItem>> GetList();
    }
}
