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
        public Task Delete(int contactId) => _contactsService.Delete(contactId);

        [HttpPost("[action]")]
        public Task Post(ContactAllData c) => _contactsService.Save(c);

        [HttpPut("[action]")]
        public void Put(ContactAllData c) => _contactsService.Update(c);
    }
}