using System.Linq;
using Microsoft.EntityFrameworkCore;
using PhoneBook.Abstract;

namespace PhoneBook.DAL.Abstract
{
    public interface IQuery
    {
        IQueryable<T> Of<T>() where T : class;
    }

    public class Query : IQuery
    {
        private readonly DbContext _dbContext;

        public Query(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<T> Of<T>() where T : class
        {
            var iDeletableName = typeof(IDeletable).AssemblyQualifiedName;
            var doesImplement = typeof(T).GetInterfaces().Any(i => i.AssemblyQualifiedName == iDeletableName);
            var set = _dbContext.Set<T>();
            return doesImplement ? set.Cast<IDeletable>().Where(m => !m.IsDeleted).Cast<T>() : set;
        }
    }
}