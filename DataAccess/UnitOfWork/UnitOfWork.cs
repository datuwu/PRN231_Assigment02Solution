using BussinessObjects;
using DataAccess.Repos;

namespace DataAccess.UnitOfWork
{
    public class UnitOfWork : IDisposable
    {
        private EBookstoreContext context = new EBookstoreContext();
        private GenericRepository<Author> authorRepository;
        private GenericRepository<BookAuthor> bookAuthorRepository;

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
