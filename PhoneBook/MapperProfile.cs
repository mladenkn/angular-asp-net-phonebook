using System.Linq;
using AutoMapper;
using PhoneBook.Models;

namespace PhoneBook
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Contact, ContactListItem>()
                .ForMember(c => c.Tags, config => config.MapFrom(c => c.Tags.Select(t => t.Value)));
        }
    }
}
