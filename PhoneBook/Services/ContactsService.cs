using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using PhoneBook.Models;

namespace PhoneBook.Services
{
    public interface IContactsService
    {
        Task<ContactAllData> GetDetails(int contactId);
        Task<IEnumerable<ContactListItem>> GetList(GetContactListRequest r);
        Task Save(ContactAllData nc);
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

        public Task<ContactAllData> GetDetails(int contactId) => _repo.GetDetails(contactId);

        public Task<IEnumerable<ContactListItem>> GetList(GetContactListRequest r) => _repo.GetList(r);

        public async Task Save(ContactAllData nc)
        {
            var dbModel = _mapper.Map<Contact>(nc);
            _unitOfWork.Add(dbModel);
            await _unitOfWork.PersistChanges();
        }
    }
}
