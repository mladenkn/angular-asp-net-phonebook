using System.Threading.Tasks;
using PhoneBook.Abstract;

namespace PhoneBook.DAL.Abstract
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

        public void Delete(IDeletable m)
        {
            m.IsDeleted = true;
            _dbContext.Update(m);
        }

        public async Task PersistChanges() => await _dbContext.SaveChangesAsync();
    }
}