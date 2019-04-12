using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PhoneBook.Models;
using PhoneBook.Services;

namespace PhoneBook.Web.Controllers
{
    [Route("api/[controller]")]
    public class ContactsController 
    {
        private readonly IContactsService _contactsService;

        public ContactsController(IContactsService contactsService)
        {
            _contactsService = contactsService;
        }

        [HttpGet("[action]/{contactId}")]
        public Task<ContactAllData> Details(int contactId) => _contactsService.GetDetails(contactId);

        [HttpPost("[action]")]
        public Task<IEnumerable<ContactListItem>> List(GetContactListRequest r) => 
            _contactsService.GetList(r);

        [HttpDelete("[action]/{contactId}")]
        public void Delete(int contactId)
        {

        }

        [HttpPost("[action]")]
        public void Post(ContactAllData c)
        {

        }

        [HttpPut("[action]")]
        public void Put(ContactAllData c)
        {

        }
    }
}