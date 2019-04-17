using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace PhoneBook.DAL
{
    public enum DataBaseType
    {
        InMemory, SqlServer
    }

    public static class AddServices
    {
        public static IServiceCollection AddPhoneBookDal(this IServiceCollection services, DataBaseType dbType = DataBaseType.SqlServer)
        {
            if(dbType == DataBaseType.InMemory)
                services.AddEntityFrameworkInMemoryDatabase();
            services.AddDbContext<PhoneBookDbContext>(o =>
            {
                if(dbType == DataBaseType.InMemory)
                    o.UseInMemoryDatabase("PhonebookDb");
            });
            services.AddTransient<DbContext, PhoneBookDbContext>();

            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IQuery, Query>();
            services.AddTransient<IContactDataProvider, ContactDataProvider>();

            return services;
        }
    }
}
