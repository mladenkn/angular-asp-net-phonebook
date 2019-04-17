﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PhoneBook.DAL;

namespace PhoneBook.DAL.Migrations
{
    [DbContext(typeof(PhoneBookDbContext))]
    [Migration("20190417140549_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PhoneBook.Models.Contact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("LastName");

                    b.HasKey("Id");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("PhoneBook.Models.Contact+Email", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ContactId");

                    b.Property<string>("Value");

                    b.HasKey("Id");

                    b.HasIndex("ContactId");

                    b.ToTable("ContactEmails");
                });

            modelBuilder.Entity("PhoneBook.Models.Contact+PhoneNumber", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ContactId");

                    b.Property<long>("Value");

                    b.HasKey("Id");

                    b.HasIndex("ContactId");

                    b.ToTable("ContactPhoneNumbers");
                });

            modelBuilder.Entity("PhoneBook.Models.Contact+Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ContactId");

                    b.Property<string>("Value");

                    b.HasKey("Id");

                    b.HasIndex("ContactId");

                    b.ToTable("ContactTags");
                });

            modelBuilder.Entity("PhoneBook.Models.Contact+Email", b =>
                {
                    b.HasOne("PhoneBook.Models.Contact")
                        .WithMany("Emails")
                        .HasForeignKey("ContactId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PhoneBook.Models.Contact+PhoneNumber", b =>
                {
                    b.HasOne("PhoneBook.Models.Contact")
                        .WithMany("PhoneNumbers")
                        .HasForeignKey("ContactId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PhoneBook.Models.Contact+Tag", b =>
                {
                    b.HasOne("PhoneBook.Models.Contact")
                        .WithMany("Tags")
                        .HasForeignKey("ContactId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}