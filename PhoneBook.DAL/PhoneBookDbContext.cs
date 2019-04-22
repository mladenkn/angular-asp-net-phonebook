using Microsoft.EntityFrameworkCore;
using PhoneBook.Models;

namespace PhoneBook.DAL
{
    public class PhoneBookDbContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<ContactEmail> ContactEmails { get; set; }
        public DbSet<ContactPhoneNumber> ContactPhoneNumbers { get; set; }
        public DbSet<ContactTag> ContactTags { get; set; }
        public DbSet<Tag> Tags { get; set; }

        public PhoneBookDbContext(DbContextOptions o) : base(o)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        protected override void OnModelCreating(ModelBuilder b)
        {
            b.Entity<ContactEmail>().HasKey(e => new {e.Value, e.ContactId});
            b.Entity<ContactPhoneNumber>().HasKey(e => new { e.Value, e.ContactId });
            b.Entity<ContactTag>().HasKey(e => new {e.TagId, e.ContactId});
            b.Entity<Tag>().HasIndex(t => t.Value).IsUnique();
        }
    }
}
