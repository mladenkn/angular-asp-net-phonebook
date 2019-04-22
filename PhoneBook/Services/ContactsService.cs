using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PhoneBook.Abstract;
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
        private readonly IContactDataProvider _contactData;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDataProvider _data;

        public ContactsService(
            IContactDataProvider contactData, IMapper mapper, IUnitOfWork unitOfWork, IDataProvider data)
        {
            _contactData = contactData;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _data = data;
        }

        public Task<ContactAllData> GetAllContactData(int contactId) => _contactData.GetAllContactData(contactId);

        public Task<IEnumerable<ContactListItem>> GetList(GetContactListRequest r) => _contactData.GetList(r);

        public async Task Save(ContactAllData c)
        {
            var dbModel = _mapper.Map<Contact>(c);
            _unitOfWork.Add(dbModel);
            await _unitOfWork.PersistChanges();
            c.Id = dbModel.Id;
        }

        public async Task Delete(int contactId)
        {
            var m = await _contactData.GetOne(contactId);
            if (m == null)
                throw new ModelNotFoundException();
            _unitOfWork.Delete(m);
            await _unitOfWork.PersistChanges();
        }

        public async Task Update(ContactAllData contact)
        {
            var contactDbModel = await _contactData.GetOne(
                contact.Id,
                includes => includes.Add(c => c.Tags).Add(c => c.Emails).Add(c => c.PhoneNumbers)
            );

            _unitOfWork.DeleteRange(contactDbModel.Tags);
            _unitOfWork.DeleteRange(contactDbModel.Emails);
            _unitOfWork.DeleteRange(contactDbModel.PhoneNumbers);

            await _unitOfWork.PersistChanges();

            var tagModels = await MapToTagModelsAndEnsureTheyArePersisted(contact.Tags);

            var tagRelationModels = tagModels.Select(t =>
                new ContactTag {ContactId = contact.Id, TagId = t.Id});

            _unitOfWork.Update(contactDbModel);
            _unitOfWork.Add(tagRelationModels);

            await _unitOfWork.PersistChanges();
        }

        private async Task<IEnumerable<Tag>> MapToTagModelsAndEnsureTheyArePersisted(IEnumerable<string> tags)
        {
            var tagModels = tags.Select(v => new Tag { Value = v });
            var tagsNotSaved = await _data.TagsNotSaved(tagModels);
            _unitOfWork.AddRange(tagsNotSaved);
             await _unitOfWork.PersistChanges();
            return tagModels;
        }
    }
}
