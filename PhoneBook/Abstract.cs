using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook
{
    public interface IUnitOfWork
    {
        void Add(object m);
        void Update(object m);
        void Delete(object m);
        void Delete(IDeletable m);
        Task PersistChanges();
    }

    public interface IDeletable
    {
        bool IsDeleted { get; set; }
    }
}
