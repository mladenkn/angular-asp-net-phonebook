using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

    public static class UnitOfWorkExtensions
    {
        public static void AddRange(this IUnitOfWork unitOfWork, IEnumerable<object> models)
        {
            foreach (var m in models)
                unitOfWork.Add(m);
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

    public interface IDeletable
    {
        bool IsDeleted { get; set; }
    }

    public class IncludesBuilder<TModel>
    {
        public IReadOnlyCollection<string> Includes { get; } = new List<string>();

        public IncludesBuilder<TModel> Add(Expression<Func<TModel, object>> exp)
        {
            var expBodyString = exp.Body.ToString();
            var indexOfFirstDot = expBodyString.IndexOf(".");
            var propName = expBodyString.Substring(indexOfFirstDot + 1);
            ((List<string>) Includes).Add(propName);
            return this;
        }
    }
}
