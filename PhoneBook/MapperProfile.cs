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

            CreateMap<Contact, ContactAllData>()
                .ForMember(cd => cd.PhoneNumbers,
                    config => config.MapFrom(c => c.PhoneNumbers.Select(pn => pn.Value)))
                .ForMember(cd => cd.Emails, config => config.MapFrom(c => c.Emails.Select(e => e.Value)))
                .ForMember(cd => cd.Tags, config => config.MapFrom(c => c.Tags.Select(e => e.Value)))
                ;
            
            CreateMap<ContactAllData, Contact>()

                .ForMember(c => c.PhoneNumbers,
                    config => config.MapFrom(cd => cd.PhoneNumbers.Select(
                        pn => new Contact.PhoneNumber { Value = pn, ContactId = cd.Id })))

                .ForMember(c => c.Emails, config => config.MapFrom(cd => cd.Emails.Select(
                    e => new Contact.Email { Value = e, ContactId = cd.Id })))

                .ForMember(c => c.Tags, config => config.MapFrom(cd => cd.Tags.Select(
                    t => new Contact.Tag { Value = t, ContactId = cd.Id })))
                ;
        }
    }
}
