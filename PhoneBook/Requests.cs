using System.Collections.Generic;

namespace PhoneBook
{
    public class GetContactListRequest
    {
        public string FirstNameSearchString { get; set; }
        public string LastNameSearchString { get; set; }
        public IEnumerable<string> ContactMustContainAllTags { get; set; }
        public IEnumerable<string> ContactMustContainSomeTags { get; set; }
    }
}
