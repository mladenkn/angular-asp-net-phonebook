using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PhoneBook.Abstract;

namespace PhoneBook.DAL.Abstract
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _dbContext;

        public UnitOfWork(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Save(object m) => _dbContext.Add(m);

        public void Update(object m) => _dbContext.Update(m);

        public void Delete(object m) => _dbContext.Remove(m);

        public void Delete(IDeletable m)
        {
            m.IsDeleted = true;
            _dbContext.Update(m);
        }

        public async Task PersistChanges() => await _dbContext.SaveChangesAsync();
    }
}