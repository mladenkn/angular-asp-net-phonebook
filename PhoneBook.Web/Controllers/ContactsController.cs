using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PhoneBook.Models;
using PhoneBook.Services;

namespace PhoneBook.Web.Controllers
{
    [Route("api/[controller]")]
    public class ContactsController : Controller
    {
        private readonly IContactsService _contactsService;
        private readonly ISafeRunner _safeRunner;

        public ContactsController(IContactsService contactsService, ISafeRunner safeRunner)
        {
            _contactsService = contactsService;
            _safeRunner = safeRunner;
        }

        [HttpGet("[action]/{contactId}")]
        public Task<IActionResult> Details(int contactId) =>
            _safeRunner.Run(() =>_contactsService.GetDetails(contactId), Ok);

        [HttpPost("[action]")]
        public Task<IActionResult> List(GetContactListRequest r) =>
            _safeRunner.Run(() => _contactsService.GetList(r), Ok);

        [HttpDelete("[action]/{contactId}")]
        public Task Delete(int contactId) => _safeRunner.Run(() => _contactsService.Delete(contactId), Ok);

        [HttpPost("[action]")]
        public Task Post(Contact c) => _safeRunner.Run(() => _contactsService.Save(c), Ok);

        [HttpPut("[action]")]
        public Task Put(Contact c) => _safeRunner.Run(() => _contactsService.Update(c), Ok);
    }
}