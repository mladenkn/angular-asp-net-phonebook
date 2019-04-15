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
    }
}
