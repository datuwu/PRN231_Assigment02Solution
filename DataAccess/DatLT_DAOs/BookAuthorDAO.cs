using BussinessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAOs
{
    public class BookAuthorDAO
    {
        private static BookAuthorDAO instance;
        public static readonly object instanceLock = new object();

        private BookAuthorDAO() { }
        public static BookAuthorDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new BookAuthorDAO();
                    }
                    return instance;
                }
            }
        }

        public async Task<IEnumerable<BookAuthor>> GetAllAsync()
        {
            IEnumerable<BookAuthor> list;

            try
            {
                var context = new EBookstoreContext();

                list = await context.Set<BookAuthor>().ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return list;
        }

        public async Task<BookAuthor?> GetByIdAsync(int bookId, int authorId)
        {
            BookAuthor? entity;

            try
            {
                var context = new EBookstoreContext();

                entity = await context
                    .Set<BookAuthor>()
                    .FirstOrDefaultAsync(x => x.AuthorId == authorId && x.BookId == bookId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return entity;
        }

        public async Task InsertAsync(BookAuthor entity)
        {
            try
            {
                var context = new EBookstoreContext();
                context.Add(entity);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task UpdateAsync(BookAuthor entity)
        {
            try
            {
                var context = new EBookstoreContext();
                context.Update(entity);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task DeleteAsync(BookAuthor entity)
        {
            try
            {
                var context = new EBookstoreContext();
                context.Remove(entity);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
