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
        Task Save(ContactAllData contact);
        Task Delete(int contactId);
        Task Update(ContactAllData contactAllData);
    }

    public class ContactsService : IContactsService
    {
        private readonly IContactDataProvider _contactData;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppService _appService;

        public ContactsService(
            IContactDataProvider contactData,
            IMapper mapper,
            IUnitOfWork unitOfWork,
            IAppService appService)
        {
            _contactData = contactData;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _appService = appService;
        }

        public Task<ContactAllData> GetAllContactData(int contactId) => _contactData.GetAllContactData(contactId);

        public Task<IEnumerable<ContactListItem>> GetList(GetContactListRequest r) => _contactData.GetList(r);

        public async Task Save(ContactAllData contact)
        {
            EnsureConsistency(contact);
            var contactDbModel = _mapper.Map<Contact>(contact);
            await _appService.IdentifyTags(contactDbModel.Tags.Select(e => e.Tag));
            _unitOfWork.Save(contactDbModel);
            await _unitOfWork.PersistChanges();
            contact.Id = contactDbModel.Id;
        }

        public async Task Delete(int contactId)
        {
            var m = await _contactData.GetOne(contactId);
            if (m == null)
                throw new ModelNotFoundException();
            _unitOfWork.Delete(m);
            await _unitOfWork.PersistChanges();
        }

        public async Task Update(ContactAllData contactAllData)
        {
            var currentContactDbModel = await _contactData.GetOne(
                contactAllData.Id,
                includes => includes.Add(c => c.Tags).Add(c => c.Emails).Add(c => c.PhoneNumbers)
            );

            _unitOfWork.DeleteRange(currentContactDbModel.Tags);
            _unitOfWork.DeleteRange(currentContactDbModel.Emails);
            _unitOfWork.DeleteRange(currentContactDbModel.PhoneNumbers);
            await _unitOfWork.PersistChanges();


            EnsureConsistency(contactAllData);
            var updatedContactDbModel = _mapper.Map<Contact>(contactAllData);

            var contactTags = updatedContactDbModel.Tags.Select(e => e.Tag);
            await _appService.IdentifyTags(contactTags);

            foreach (var contactTag in updatedContactDbModel.Tags)
                contactTag.RefreshTagId();

            _unitOfWork.Update(updatedContactDbModel);
            _unitOfWork.SaveRange(updatedContactDbModel.Emails);
            _unitOfWork.SaveRange(updatedContactDbModel.PhoneNumbers);
            _unitOfWork.SaveRange(contactTags.Where(e => e.Id == 0));
            _unitOfWork.SaveRange(updatedContactDbModel.Tags);

            await _unitOfWork.PersistChanges();
        }

        private void EnsureConsistency(ContactAllData contact)
        {
            contact.Tags = contact.Tags != null ? contact.Tags.Distinct() : new string[] {};
            contact.Emails = contact.Emails != null ? contact.Emails.Distinct() : new string[] {};
            contact.PhoneNumbers = contact.PhoneNumbers != null ? contact.PhoneNumbers.Distinct() : new long[] {};
        }
    }
}
