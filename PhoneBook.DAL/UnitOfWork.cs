using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PhoneBook.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PhoneBookDbContext _dbContext;

        public UnitOfWork(PhoneBookDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(object m) => _dbContext.Add(m);

        public void Update(object m) => _dbContext.Update(m);

        public void Delete(object m) => _dbContext.Remove(m);

        public async Task PersistChanges() => await _dbContext.SaveChangesAsync();
    }
}
