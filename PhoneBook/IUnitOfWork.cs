using System.Threading.Tasks;

namespace PhoneBook
{
    public interface IUnitOfWork
    {
        void Add(object m);
        void Update(object m);
        void Delete(object m);
        Task PersistChanges();
    }
}
