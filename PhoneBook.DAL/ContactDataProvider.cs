using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PhoneBook.Models;

namespace PhoneBook.DAL
{
    public class ContactDataProvider : IContactDataProvider
    {
        private readonly PhoneBookDbContext _dbContext;
        private readonly IMapper _mapper;

        public ContactDataProvider(PhoneBookDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public Task<Contact> GetOne(int contactId, Action<IncludesBuilder<Contact>> include)
        {
            void IncludeDefault(IncludesBuilder<Contact> b) { }

            return _dbContext.Contacts
                .Where(c => !c.IsDeleted)
                .Include(include ?? IncludeDefault)
                .FirstOrDefaultAsync(c => c.Id == contactId);
        }

        public async Task<ContactAllData> GetAllContactData(int contactId)
        {
            var r = await _dbContext.Contacts
                .Where(c => !c.IsDeleted)
                .Include(c => c.Emails)
                .Include(c => c.Tags)
                .Include(c => c.PhoneNumbers)
                .FirstOrDefaultAsync(c => c.Id == contactId);

            return _mapper.Map<ContactAllData>(r);
        }

        public async Task<IEnumerable<ContactListItem>> GetList(GetContactListRequest r)
        {
            var models = await _dbContext.Contacts
                .Where(c => !c.IsDeleted)
                .Include(c => c.Tags)
                .ToListAsync();
            return models.Select(m => _mapper.Map<ContactListItem>(m));
        }
    }
}
