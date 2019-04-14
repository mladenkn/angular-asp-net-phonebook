using System.Linq;
using AutoMapper;
using PhoneBook.Models;

namespace PhoneBook
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Contact, ContactListItem>();

            CreateMap<Contact, ContactAllData>()
                .ForMember(cd => cd.PhoneNumbers,
                    config => config.MapFrom(c => c.PhoneNumbers.Select(pn => pn.PhoneNumber)))
                .ForMember(cd => cd.Emails, config => config.MapFrom(c => c.Emails.Select(e => e.Email)))
                .ForMember(cd => cd.Tags, config => config.MapFrom(c => c.Tags.Select(e => e.Tag)))
                ;


            CreateMap<ContactAllData, Contact>()

                .ForMember(c => c.PhoneNumbers,
                    config => config.MapFrom(cd => cd.PhoneNumbers.Select(
                        pn => new ContactPhoneNumber { PhoneNumber = pn, ContactId = cd.Id })))

                .ForMember(c => c.Emails, config => config.MapFrom(cd => cd.Emails.Select(
                    e => new ContactEmail { Email = e, ContactId = cd.Id })))

                .ForMember(c => c.Tags, config => config.MapFrom(cd => cd.Tags.Select(
                    t => new ContactTag { Tag = t, ContactId = cd.Id })))
                ;
        }
    }
}
