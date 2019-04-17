using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PhoneBook.Abstract;
using PhoneBook.DAL.Abstract;
using PhoneBook.Models;

namespace PhoneBook.DAL
{
    public class ContactDataProvider : IContactDataProvider
    {
        private readonly IQuery _query;
        private readonly IMapper _mapper;

        public ContactDataProvider(IQuery query, IMapper mapper)
        {
            _query = query;
            _mapper = mapper;
        }

        public Task<Contact> GetOne(int contactId, Action<IncludesBuilder<Contact>> include)
        {
            void IncludeDefault(IncludesBuilder<Contact> b) { }

            return _query.Of<Contact>()
                .Include(include ?? IncludeDefault)
                .FirstOrDefaultAsync(c => c.Id == contactId);
        }

        public async Task<ContactAllData> GetAllContactData(int contactId)
        {
            var r = await _query.Of<Contact>()
                .Include(c => c.Emails)
                .Include(c => c.Tags)
                .Include(c => c.PhoneNumbers)
                .FirstOrDefaultAsync(c => c.Id == contactId);

            return _mapper.Map<ContactAllData>(r);
        }

        public async Task<IEnumerable<ContactListItem>> GetList(GetContactListRequest r)
        {
            r.ContactMustContainAllTags = r.ContactMustContainAllTags ?? new string[] { };
            r.ContactMustContainSomeTags = r.ContactMustContainSomeTags ?? new string[] { };

            var strComp = StringComparison.CurrentCultureIgnoreCase;

            var models = await _query.Of<Contact>()
                .Include(c => c.Tags)
                //.Where(c => r.FirstNameSearchString == null || c.FirstName.ToLower().Contains(r.FirstNameSearchString.ToLower()) &&
                //    r.LastNameSearchString == null || c.LastName.ToLower().Contains(r.LastNameSearchString.ToLower()) &&
                //    r.ContactMustContainAllTags.All(
                //        t => c.Tags.Any(t2 => string.Equals(t, t2.Value, strComp))) &&
                //    r.ContactMustContainSomeTags.Any(
                //        t => c.Tags.Any(t2 => string.Equals(t, t2.Value, strComp)))
                //)
                .ToListAsync();

            return models.Select(m => _mapper.Map<ContactListItem>(m));
        }
    }
}
