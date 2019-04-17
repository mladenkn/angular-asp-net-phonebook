using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PhoneBook.DAL;
using PhoneBook.Services;

namespace PhoneBook.Web
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();
            using (var services = host.Services.CreateScope())
            {
                var db = services.ServiceProvider.GetService<PhoneBookDbContext>();
                var countOfContacts = await db.Contacts.CountAsync();
                if (countOfContacts == 0)
                {
                    var contactService = services.ServiceProvider.GetService<IContactsService>();
                    await DataInitializer.Initialize(contactService);
                }
            }
            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
