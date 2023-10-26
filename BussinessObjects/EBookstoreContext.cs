using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObjects
{
    public class EBookstoreContext : DbContext
    {
        public EBookstoreContext()
        {
        }

        public EBookstoreContext(DbContextOptions<EBookstoreContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<BookAuthor> BooksAuthors { get; set; }
        public virtual DbSet<Publisher> Publishers { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            IConfigurationRoot configuration = builder.Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            optionsBuilder.LogTo(Console.WriteLine).EnableSensitiveDataLogging();

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed data for Authors
            modelBuilder.Entity<Author>().HasData(
                new Author { Id = 1, FirstName = "John", LastName = "Doe", Phone = "123-456-7890", Email = "john.doe@example.com", Address = "123 Main St", City = "New York", State = "NY", Zip = "10001" },
                new Author { Id = 2, FirstName = "Jane", LastName = "Smith", Phone = "987-654-3210", Email = "jane.smith@example.com", Address = "456 Elm St", City = "Los Angeles", State = "CA", Zip = "90001" },
                new Author { Id = 3, FirstName = "Michael", LastName = "Johnson", Phone = "555-555-5555", Email = "michael.johnson@example.com", Address = "789 Oak St", City = "Chicago", State = "IL", Zip = "60001" },
                new Author { Id = 4, FirstName = "Emily", LastName = "Brown", Phone = "111-222-3333", Email = "emily.brown@example.com", Address = "101 Pine St", City = "London", State = null, Zip = "W1A 1AA" },
                new Author { Id = 5, FirstName = "David", LastName = "Wilson", Phone = "444-444-4444", Email = "david.wilson@example.com", Address = "555 Cedar St", City = "Sydney", State = "NSW", Zip = "2000" }
            );

            // Seed data for Books
            modelBuilder.Entity<Book>().HasData(
                new Book { Id = 1, Title = "Book 1", Type = "Fiction", PublisherId = 1, Price = 19.99, Advance = "10.00", Royalty = "20.00", YTDSales = null, Note = "Great book!", PublishedDate = new DateTime(2023, 9, 15) },
                new Book { Id = 2, Title = "Book 2", Type = "Non-Fiction", PublisherId = 2, Price = 24.99, Advance = "15.00", Royalty = "25.00", YTDSales = null, Note = "Informative", PublishedDate = new DateTime(2023, 8, 20) },
                new Book { Id = 3, Title = "Book 3", Type = "Mystery", PublisherId = 3, Price = 17.99, Advance = "12.00", Royalty = "22.00", YTDSales = null, Note = "Thriller", PublishedDate = new DateTime(2023, 6, 10) },
                new Book { Id = 4, Title = "Book 4", Type = "Science Fiction", PublisherId = 4, Price = 21.99, Advance = "14.00", Royalty = "24.00", YTDSales = null, Note = "Out of this world", PublishedDate = new DateTime(2023, 4, 25) },
                new Book { Id = 5, Title = "Book 5", Type = "Romance", PublisherId = 5, Price = 14.99, Advance = "8.00", Royalty = "18.00", YTDSales = null, Note = "Love story", PublishedDate = new DateTime(2023, 2, 5) }

            );

            // Seed data for Publishers
            modelBuilder.Entity<Publisher>().HasData(
                new Publisher { Id = 1, PublisherName = "Publisher A", City = "New York", State = "NY", Country = "USA" },
                new Publisher { Id = 2, PublisherName = "Publisher B", City = "Los Angeles", State = "CA", Country = "USA" },
                new Publisher { Id = 3, PublisherName = "Publisher C", City = "Chicago", State = "IL", Country = "USA" },
                new Publisher { Id = 4, PublisherName = "Publisher D", City = "London", State = "DJ", Country = "UK" },
                new Publisher { Id = 5, PublisherName = "Publisher E", City = "Sydney", State = "NSW", Country = "Australia" }
            );

            // Seed data for Roles
            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, Description = "Admin" },
                new Role { Id = 2, Description = "Editor" },
                new Role { Id = 3, Description = "Author" },
                new Role { Id = 4, Description = "Reader" },
                new Role { Id = 5, Description = "Guest" }
            );

            // Seed data for Users (User's PublisherId should match Publisher Id)
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Email = "admin@example.com", Password = "adminpass", Source = "Internal", FirstName = "Admin", MiddleName = null, LastName = null, RoleId = 1, PublisherId = null, HireDate = new DateTime(2021, 1, 1) },
                new User { Id = 2, Email = "editor@example.com", Password = "editorpass", Source = "Internal", FirstName = "Editor", MiddleName = null, LastName = null, RoleId = 2, PublisherId = null, HireDate = new DateTime(2021, 2, 1) },
                new User { Id = 3, Email = "author@example.com", Password = "authorpass", Source = "External", FirstName = "Author", MiddleName = null, LastName = null, RoleId = 3, PublisherId = 1, HireDate = new DateTime(2021, 3, 1) },
                new User { Id = 4, Email = "reader@example.com", Password = "readerpass", Source = "External", FirstName = "Reader", MiddleName = null, LastName = null, RoleId = 4, PublisherId = 2, HireDate = new DateTime(2021, 4, 1) },
                new User { Id = 5, Email = "guest@example.com", Password = "guestpass", Source = "External", FirstName = "Guest", MiddleName = null, LastName = null, RoleId = 5, PublisherId = null, HireDate = new DateTime(2021, 5, 1) }
            );

            modelBuilder.Entity<BookAuthor>().HasData(
                new BookAuthor { AuthorId = 1, BookId = 1, AuthorOrder = "Primary", RoyalityPercentage = 10 },
                new BookAuthor { AuthorId = 2, BookId = 1, AuthorOrder = "Secondary", RoyalityPercentage = 20 },
                new BookAuthor { AuthorId = 3, BookId = 2, AuthorOrder = "Primary", RoyalityPercentage = 15 },
                new BookAuthor { AuthorId = 4, BookId = 3, AuthorOrder = "Primary", RoyalityPercentage = 12 },
                new BookAuthor { AuthorId = 5, BookId = 4, AuthorOrder = "Primary", RoyalityPercentage = 18 }
            );

            modelBuilder.Entity<BookAuthor>().HasKey(e => new { e.BookId, e.AuthorId });

            base.OnModelCreating(modelBuilder);
        }
    }
}
