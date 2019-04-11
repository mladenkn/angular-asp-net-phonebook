using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using PhoneBook.Models;

namespace PhoneBook.Services
{
    public interface IContactsService
    {
        Task<ContactDetails> GetDetails(int contactId);
        Task<IEnumerable<ContactListItem>> GetList();
        Task Save(NewContactParams nc);
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

        public Task<ContactDetails> GetDetails(int contactId) => _repo.GetDetails(contactId);

        public Task<IEnumerable<ContactListItem>> GetList() => _repo.GetList();

        public async Task Save(NewContactParams nc)
        {
            var dbModel = _mapper.Map<Contact>(nc);
            _unitOfWork.Add(dbModel);
            await _unitOfWork.PersistChanges();
        }
    }
}
