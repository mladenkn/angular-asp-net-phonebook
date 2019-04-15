using Microsoft.EntityFrameworkCore;
using PhoneBook.Models;

namespace PhoneBook.DAL
{
    public class PhoneBookDbContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Contact.Email> ContactEmails { get; set; }
        public DbSet<Contact.PhoneNumber> ContactPhoneNumbers { get; set; }
        public DbSet<Contact.Tag> ContactTags { get; set; }

        public PhoneBookDbContext(DbContextOptions o) : base(o)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
    }
}
