using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using PhoneBook.DAL;

namespace PhoneBook.Tests
{
    public class ServicesFactory
    {
        public static PhoneBookDbContext DbContextInMemory()
        {
            var options = new DbContextOptionsBuilder<PhoneBookDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            return new PhoneBookDbContext(options);
        }

        public static (PhoneBookDbContext, IDbConnection) DbContext()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();
            var options = new DbContextOptionsBuilder<PhoneBookDbContext>()
                .UseSqlite(connection)
                .EnableSensitiveDataLogging()
                .Options;
            var db = new PhoneBookDbContext(options);
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();
            return (db, connection);
        }

        public static MapperConfiguration MapperConfiguration() => 
            new MapperConfiguration(c => c.AddProfile(new MapperProfile()));
    }
}
