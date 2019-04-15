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

        public void Delete(IDeletable m)
        {
            m.IsDeleted = true;
            _dbContext.Update(m);
        }

        public async Task PersistChanges() => await _dbContext.SaveChangesAsync();
    }

    public static class QueryableExtensions
    {
        public static IQueryable<T> Include<T>(
            this IQueryable<T> queryable, Action<IncludesBuilder<T>> include) where T : class
        {
            var includesBuilder = new IncludesBuilder<T>();
            include(includesBuilder);

            foreach (var propToInclude in includesBuilder.Includes)
                queryable = queryable.Include(propToInclude);

            return queryable;
        }
    }
}
