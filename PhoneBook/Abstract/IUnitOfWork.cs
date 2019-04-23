using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhoneBook.Abstract
{
    public interface IUnitOfWork
    {
        void Save(object m);
        void Update(object m);
        void Delete(object m);
        void Delete(IDeletable m);
        Task PersistChanges();
    }

    public static class UnitOfWorkExtensions
    {
        public static void SaveRange(this IUnitOfWork unitOfWork, IEnumerable<object> models)
        {
            foreach (var m in models)
                unitOfWork.Save(m);
        }

        public static void UpdateRange(this IUnitOfWork unitOfWork, IEnumerable<object> models)
        {
            foreach (var m in models)
                unitOfWork.Update(m);
        }

        public static void DeleteRange(this IUnitOfWork unitOfWork, IEnumerable<object> models)
        {
            foreach (var m in models)
                unitOfWork.Delete(m);
        }
    }
}
