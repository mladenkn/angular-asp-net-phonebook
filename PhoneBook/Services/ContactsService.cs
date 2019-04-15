using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PhoneBook.Models;

namespace PhoneBook.Services
{
    public interface IContactsService
    {
        Task<Contact> GetDetails(int contactId);
        Task<IEnumerable<ContactListItem>> GetList(GetContactListRequest r);
        Task Save(Contact c);
        Task Delete(int contactId);
        Task Update(Contact c);
    }

    public class ContactsService : IContactsService
    {
        private readonly IContactRepository _repo;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ContactsService(IContactRepository repo, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _repo = repo;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public Task<Contact> GetDetails(int contactId) => _repo.GetDetails(contactId);

        public Task<IEnumerable<ContactListItem>> GetList(GetContactListRequest r) => _repo.GetList(r);

        public async Task Save(Contact c)
        {
            _unitOfWork.Add(c);

            foreach (var t in c.Tags)
                t.ContactId = c.Id;
            foreach (var e in c.Emails)
                e.ContactId = c.Id;
            foreach (var pn in c.PhoneNumbers)
                pn.ContactId = c.Id;

            await _unitOfWork.PersistChanges();
        }

        public async Task Delete(int contactId)
        {
            var m = await _repo.GetOne(contactId);
            _unitOfWork.Delete(m);
            await _unitOfWork.PersistChanges();
        }

        public async Task Update(Contact c)
        {
            _unitOfWork.Update(c);

            _unitOfWork.UpdateRange(c.PhoneNumbers.Where(pn => pn.Id > 0));
            _unitOfWork.UpdateRange(c.Emails.Where(pn => pn.Id > 0));
            _unitOfWork.UpdateRange(c.Tags.Where(pn => pn.Id > 0));

            _unitOfWork.Add(c.PhoneNumbers.Where(pn => pn.Id == 0));
            _unitOfWork.Add(c.Emails.Where(pn => pn.Id == 0));
            _unitOfWork.Add(c.Tags.Where(pn => pn.Id == 0));

            await _unitOfWork.PersistChanges();
        }
    }
}
