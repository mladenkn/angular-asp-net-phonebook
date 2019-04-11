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

        [HttpGet("[action]")]
        public Task<ContactDetails> GetDetails(int contactId) => _contactsService.GetDetails(contactId);

        [HttpGet("[action]")]
        public Task<IEnumerable<ContactListItem>> GetList(int contactId) => _contactsService.GetList();
    }
}