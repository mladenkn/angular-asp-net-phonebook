using Xunit;

namespace PhoneBook.Tests
{
    public class AutoMapperProfilesTest
    {
        [Fact]
        public void Run()
        {
            ServicesFactory.MapperConfiguration().AssertConfigurationIsValid();
        }
    }
}
