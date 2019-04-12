using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PhoneBook.Models;

namespace PhoneBook.DAL
{
    public class ContactRepository : IContactRepository
    {
        private readonly PhoneBookDbContext _dbContext;
        private readonly IMapper _mapper;

        public ContactRepository(PhoneBookDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ContactAllData> GetDetails(int contactId)
        {
            var contact = await _dbContext.Contacts
                .Include(c => c.Emails)
                .Include(c => c.Tags)
                .Include(c => c.PhoneNumbers)
                .FirstOrDefaultAsync(c => c.Id == contactId);

            return _mapper.Map<ContactAllData>(contact);
        }

        public async Task<IEnumerable<ContactListItem>> GetList(GetContactListRequest r)
        {
            var models = await _dbContext.Contacts.ToListAsync();
            return models.Select(m => _mapper.Map<ContactListItem>(m));
        }
    }
}
