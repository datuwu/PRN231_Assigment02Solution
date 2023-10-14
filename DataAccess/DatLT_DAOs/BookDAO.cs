using BussinessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAOs
{
    public class BookDAO
    {
        private static BookDAO instance;
        public static readonly object instanceLock = new object();

        private BookDAO() { }
        public static BookDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new BookDAO();
                    }
                    return instance;
                }
            }
        }

        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            IEnumerable<Book> list;

            try
            {
                var context = new EBookstoreContext();

                list = await context.Set<Book>().ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return list;
        }

        public async Task<Book?> GetByIdAsync(int id)
        {
            Book? entity;

            try
            {
                var context = new EBookstoreContext();

                entity = await context.Set<Book>().FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return entity;
        }

        public async Task InsertAsync(Book entity)
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

        public async Task UpdateAsync(Book entity)
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

        public async Task DeleteAsync(Book entity)
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
