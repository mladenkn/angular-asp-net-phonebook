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

            CreateMap<Contact, ContactDetails>()
                .ForMember(cd => cd.PhoneNumbers,
                    config => config.MapFrom(c => c.PhoneNumbers.Select(pn => pn.PhoneNumber)))
                .ForMember(cd => cd.Emails, config => config.MapFrom(c => c.Emails.Select(e => e.Email)))
                .ForMember(cd => cd.Tags, config => config.MapFrom(c => c.Tags.Select(e => e.Tag)))
                ;


            CreateMap<ContactDetails, Contact>()

                .ForMember(c => c.PhoneNumbers,
                    config => config.MapFrom(cd => cd.PhoneNumbers.Select(
                        pn => new ContactPhoneNumber { PhoneNumber = pn })))

                .ForMember(c => c.Emails, config => config.MapFrom(cd => cd.Emails.Select(
                    e => new ContactEmail { Email = e })))

                .ForMember(c => c.Tags, config => config.MapFrom(cd => cd.Tags.Select(
                    t => new ContactTag { Tag = t })))
                ;


            CreateMap<NewContactArgs, Contact>()

                .ForMember(c => c.Id, config => config.Ignore())

                .ForMember(c => c.PhoneNumbers,
                    config => config.MapFrom(nc => nc.PhoneNumbers.Select(
                        pn => new ContactPhoneNumber {PhoneNumber = pn})))
                
                .ForMember(c => c.Emails, config => config.MapFrom(nc => nc.Emails.Select(
                    e => new ContactEmail {Email = e})))
                
                .ForMember(c => c.Tags, config => config.MapFrom(nc => nc.Tags.Select(
                    t => new ContactTag {Tag = t})))
                ;
        }
    }
}
