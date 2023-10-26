﻿// <auto-generated />
using System;
using BussinessObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BussinessObjects.Migrations
{
    [DbContext(typeof(EBookstoreContext))]
    partial class EBookstoreContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BussinessObjects.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Zip")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Authors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "123 Main St",
                            City = "New York",
                            Email = "john.doe@example.com",
                            FirstName = "John",
                            LastName = "Doe",
                            Phone = "123-456-7890",
                            State = "NY",
                            Zip = "10001"
                        },
                        new
                        {
                            Id = 2,
                            Address = "456 Elm St",
                            City = "Los Angeles",
                            Email = "jane.smith@example.com",
                            FirstName = "Jane",
                            LastName = "Smith",
                            Phone = "987-654-3210",
                            State = "CA",
                            Zip = "90001"
                        },
                        new
                        {
                            Id = 3,
                            Address = "789 Oak St",
                            City = "Chicago",
                            Email = "michael.johnson@example.com",
                            FirstName = "Michael",
                            LastName = "Johnson",
                            Phone = "555-555-5555",
                            State = "IL",
                            Zip = "60001"
                        },
                        new
                        {
                            Id = 4,
                            Address = "101 Pine St",
                            City = "London",
                            Email = "emily.brown@example.com",
                            FirstName = "Emily",
                            LastName = "Brown",
                            Phone = "111-222-3333",
                            Zip = "W1A 1AA"
                        },
                        new
                        {
                            Id = 5,
                            Address = "555 Cedar St",
                            City = "Sydney",
                            Email = "david.wilson@example.com",
                            FirstName = "David",
                            LastName = "Wilson",
                            Phone = "444-444-4444",
                            State = "NSW",
                            Zip = "2000"
                        });
                });

            modelBuilder.Entity("BussinessObjects.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Advance")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<DateTime?>("PublishedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("PublisherId")
                        .HasColumnType("int");

                    b.Property<string>("Royalty")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("YTDSales")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("PublisherId");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Advance = "10.00",
                            Note = "Great book!",
                            Price = 19.989999999999998,
                            PublishedDate = new DateTime(2023, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PublisherId = 1,
                            Royalty = "20.00",
                            Title = "Book 1",
                            Type = "Fiction"
                        },
                        new
                        {
                            Id = 2,
                            Advance = "15.00",
                            Note = "Informative",
                            Price = 24.989999999999998,
                            PublishedDate = new DateTime(2023, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PublisherId = 2,
                            Royalty = "25.00",
                            Title = "Book 2",
                            Type = "Non-Fiction"
                        },
                        new
                        {
                            Id = 3,
                            Advance = "12.00",
                            Note = "Thriller",
                            Price = 17.989999999999998,
                            PublishedDate = new DateTime(2023, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PublisherId = 3,
                            Royalty = "22.00",
                            Title = "Book 3",
                            Type = "Mystery"
                        },
                        new
                        {
                            Id = 4,
                            Advance = "14.00",
                            Note = "Out of this world",
                            Price = 21.989999999999998,
                            PublishedDate = new DateTime(2023, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PublisherId = 4,
                            Royalty = "24.00",
                            Title = "Book 4",
                            Type = "Science Fiction"
                        },
                        new
                        {
                            Id = 5,
                            Advance = "8.00",
                            Note = "Love story",
                            Price = 14.99,
                            PublishedDate = new DateTime(2023, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PublisherId = 5,
                            Royalty = "18.00",
                            Title = "Book 5",
                            Type = "Romance"
                        });
                });

            modelBuilder.Entity("BussinessObjects.BookAuthor", b =>
                {
                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<string>("AuthorOrder")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoyalityPercentage")
                        .HasColumnType("int");

                    b.HasKey("BookId", "AuthorId");

                    b.HasIndex("AuthorId");

                    b.ToTable("BooksAuthors");

                    b.HasData(
                        new
                        {
                            BookId = 1,
                            AuthorId = 1,
                            AuthorOrder = "Primary",
                            RoyalityPercentage = 10
                        },
                        new
                        {
                            BookId = 1,
                            AuthorId = 2,
                            AuthorOrder = "Secondary",
                            RoyalityPercentage = 20
                        },
                        new
                        {
                            BookId = 2,
                            AuthorId = 3,
                            AuthorOrder = "Primary",
                            RoyalityPercentage = 15
                        },
                        new
                        {
                            BookId = 3,
                            AuthorId = 4,
                            AuthorOrder = "Primary",
                            RoyalityPercentage = 12
                        },
                        new
                        {
                            BookId = 4,
                            AuthorId = 5,
                            AuthorOrder = "Primary",
                            RoyalityPercentage = 18
                        });
                });

            modelBuilder.Entity("BussinessObjects.Publisher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PublisherName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Publishers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            City = "New York",
                            Country = "USA",
                            PublisherName = "Publisher A",
                            State = "NY"
                        },
                        new
                        {
                            Id = 2,
                            City = "Los Angeles",
                            Country = "USA",
                            PublisherName = "Publisher B",
                            State = "CA"
                        },
                        new
                        {
                            Id = 3,
                            City = "Chicago",
                            Country = "USA",
                            PublisherName = "Publisher C",
                            State = "IL"
                        },
                        new
                        {
                            Id = 4,
                            City = "London",
                            Country = "UK",
                            PublisherName = "Publisher D",
                            State = "DJ"
                        },
                        new
                        {
                            Id = 5,
                            City = "Sydney",
                            Country = "Australia",
                            PublisherName = "Publisher E",
                            State = "NSW"
                        });
                });

            modelBuilder.Entity("BussinessObjects.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Admin"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Editor"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Author"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Reader"
                        },
                        new
                        {
                            Id = 5,
                            Description = "Guest"
                        });
                });

            modelBuilder.Entity("BussinessObjects.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("HireDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MiddleName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PublisherId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("Source")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PublisherId");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "admin@example.com",
                            FirstName = "Admin",
                            HireDate = new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Password = "adminpass",
                            RoleId = 1,
                            Source = "Internal"
                        },
                        new
                        {
                            Id = 2,
                            Email = "editor@example.com",
                            FirstName = "Editor",
                            HireDate = new DateTime(2021, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Password = "editorpass",
                            RoleId = 2,
                            Source = "Internal"
                        },
                        new
                        {
                            Id = 3,
                            Email = "author@example.com",
                            FirstName = "Author",
                            HireDate = new DateTime(2021, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Password = "authorpass",
                            PublisherId = 1,
                            RoleId = 3,
                            Source = "External"
                        },
                        new
                        {
                            Id = 4,
                            Email = "reader@example.com",
                            FirstName = "Reader",
                            HireDate = new DateTime(2021, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Password = "readerpass",
                            PublisherId = 2,
                            RoleId = 4,
                            Source = "External"
                        },
                        new
                        {
                            Id = 5,
                            Email = "guest@example.com",
                            FirstName = "Guest",
                            HireDate = new DateTime(2021, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Password = "guestpass",
                            RoleId = 5,
                            Source = "External"
                        });
                });

            modelBuilder.Entity("BussinessObjects.Book", b =>
                {
                    b.HasOne("BussinessObjects.Publisher", "Publisher")
                        .WithMany("Books")
                        .HasForeignKey("PublisherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Publisher");
                });

            modelBuilder.Entity("BussinessObjects.BookAuthor", b =>
                {
                    b.HasOne("BussinessObjects.Author", "Author")
                        .WithMany("BookAuthors")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BussinessObjects.Book", "Book")
                        .WithMany("BookAuthors")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Book");
                });

            modelBuilder.Entity("BussinessObjects.User", b =>
                {
                    b.HasOne("BussinessObjects.Publisher", "Publisher")
                        .WithMany("Users")
                        .HasForeignKey("PublisherId");

                    b.HasOne("BussinessObjects.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Publisher");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("BussinessObjects.Author", b =>
                {
                    b.Navigation("BookAuthors");
                });

            modelBuilder.Entity("BussinessObjects.Book", b =>
                {
                    b.Navigation("BookAuthors");
                });

            modelBuilder.Entity("BussinessObjects.Publisher", b =>
                {
                    b.Navigation("Books");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("BussinessObjects.Role", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
