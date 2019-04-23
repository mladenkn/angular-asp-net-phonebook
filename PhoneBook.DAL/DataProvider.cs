using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PhoneBook.DAL.Abstract;
using PhoneBook.Models;

namespace PhoneBook.DAL
{
    public class DataProvider : IDataProvider
    {
        private readonly IQuery _query;

        public DataProvider(IQuery query)
        {
            _query = query;
        }

        public async Task<IEnumerable<Tag>> GetTagsIfPersisted(IEnumerable<string> tagValues) => 
            await _query.Of<Tag>()
                .Where(e => tagValues.Contains(e.Value))
                .ToListAsync();
    }
}
