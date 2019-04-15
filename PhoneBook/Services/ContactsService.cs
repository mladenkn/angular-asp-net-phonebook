using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PhoneBook.Models;

namespace PhoneBook.Services
{
    public interface IContactsService
    {
        Task<ContactAllData> GetAllContactData(int contactId);
        Task<IEnumerable<ContactListItem>> GetList(GetContactListRequest r);
        Task Save(ContactAllData c);
        Task Delete(int contactId);
        Task Update(ContactAllData c);
    }

    public class ContactsService : IContactsService
    {
        private readonly IContactDataProvider _data;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ContactsService(IContactDataProvider data, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _data = data;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public Task<ContactAllData> GetAllContactData(int contactId) => _data.GetAllContactData(contactId);

        public Task<IEnumerable<ContactListItem>> GetList(GetContactListRequest r) => _data.GetList(r);

        public async Task Save(ContactAllData c)
        {
            var dbModel = _mapper.Map<Contact>(c);
            _unitOfWork.Add(dbModel);
            await _unitOfWork.PersistChanges();
        }

        public async Task Delete(int contactId)
        {
            var m = await _data.GetOne(contactId);
            _unitOfWork.Delete(m);
            await _unitOfWork.PersistChanges();
        }

        public async Task Update(ContactAllData contact)
        {
            var dbModelWithNewData = _mapper.Map<Contact>(contact);

            var dbModelWithOldData = await _data.GetOne(
                dbModelWithNewData.Id, 
                b => b.Add(c => c.Emails).Add(c => c.PhoneNumbers).Add(c => c.Tags)
            );
            _unitOfWork.DeleteRange(dbModelWithOldData.Emails);
            _unitOfWork.DeleteRange(dbModelWithOldData.PhoneNumbers);
            _unitOfWork.DeleteRange(dbModelWithOldData.Tags);

            await _unitOfWork.PersistChanges();

            _unitOfWork.Update(dbModelWithNewData);
            _unitOfWork.AddRange(dbModelWithNewData.Emails);
            _unitOfWork.AddRange(dbModelWithNewData.PhoneNumbers);
            _unitOfWork.AddRange(dbModelWithNewData.Tags);

            await _unitOfWork.PersistChanges();
        }
    }
}
