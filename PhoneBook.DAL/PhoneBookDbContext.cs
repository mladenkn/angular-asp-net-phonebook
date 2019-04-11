using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PhoneBook.Models;

namespace PhoneBook.DAL
{
    public class PhoneBookDbContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }

        public PhoneBookDbContext(DbContextOptions o) : base(o)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            void AddDummyPrimaryKey<T>() where T : class
            {
                modelBuilder.Entity<T>().Property<int>("Id");
                modelBuilder.Entity<T>().HasKey("Id");
            }

            AddDummyPrimaryKey<ContactEmail>();
            AddDummyPrimaryKey<ContactTag>();
            AddDummyPrimaryKey<ContactPhoneNumber>();
        }
    }
}
