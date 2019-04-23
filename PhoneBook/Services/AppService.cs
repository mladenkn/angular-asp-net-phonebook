using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhoneBook.Models;

namespace PhoneBook.Services
{
    public interface IAppService
    {
        Task IdentifyTags(IEnumerable<Tag> tags);
    }

    public class AppService : IAppService
    {
        private readonly IDataProvider _dataProvider;

        public AppService(IDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }

        public async Task IdentifyTags(IEnumerable<Tag> tags)
        {
            var onlyPersistedTags = await _dataProvider.GetTagsIfPersisted(tags.Select(e => e.Value));

            foreach (var persistedTag in onlyPersistedTags)
            {
                var tag = tags.Single(e => e.Value == persistedTag.Value);
                tag.Id = persistedTag.Id;
            }
        }
    }
}
