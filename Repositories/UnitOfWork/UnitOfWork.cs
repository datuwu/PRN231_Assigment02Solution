using BussinessObjects;
using Repositories.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.UnitOfWork
{
    public class UnitOfWork : IDisposable
    {
        private EBookstoreContext context = new EBookstoreContext();
        private GenericRepository<Author> authorRepository;
        private GenericRepository<BookAuthor> bookAuthorRepository;
        private GenericRepository<Book> bookRepository;
        private GenericRepository<Publisher> publisherRepository;
        private GenericRepository<Role> roleRepository;
        private GenericRepository<User> userRepository;


        public GenericRepository<Author> AuthorRepository
        {
            get
            {
                if (this.authorRepository == null)
                {
                    this.authorRepository = new GenericRepository<Author>(context);
                }
                return authorRepository;
            }
        }

        public GenericRepository<BookAuthor> BookAuthorRepository
        {
            get
            {

                if (this.bookAuthorRepository == null)
                {
                    this.bookAuthorRepository = new GenericRepository<BookAuthor>(context);
                }
                return bookAuthorRepository;
            }
        }

        public GenericRepository<Book> BookRepository
        {
            get
            {
                if (this.bookRepository == null)
                {
                    this.bookRepository = new GenericRepository<Book>(context);
                }
                return bookRepository;
            }
        }

        public GenericRepository<Publisher> PublisherRepository
        {
            get
            {
                if (this.publisherRepository == null)
                {
                    this.publisherRepository = new GenericRepository<Publisher>(context);
                }
                return publisherRepository;
            }
        }

        public GenericRepository<Role> RoleRepository
        {
            get
            {
                if (this.roleRepository == null)
                {
                    this.roleRepository = new GenericRepository<Role>(context);
                }
                return roleRepository;
            }
        }

        public GenericRepository<User> UserRepository
        {
            get
            {
                if (this.userRepository == null)
                {
                    this.userRepository = new GenericRepository<User>(context);
                }
                return userRepository;
            }
        }
        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
