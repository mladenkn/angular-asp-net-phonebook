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
        public Task<ContactDetails> Details(int contactId) => _contactsService.GetDetails(contactId);

        [HttpGet("[action]")]
        public Task<IEnumerable<ContactListItem>> List() => _contactsService.GetList();

        [HttpDelete("[action]/{contactId}")]
        public void Delete(int contactId)
        {

        }

        [HttpPost("[action]")]
        public void Post(NewContactArgs args)
        {

        }

        [HttpPut("[action]")]
        public void Patch(ContactDetails cd)
        {

        }
    }
}