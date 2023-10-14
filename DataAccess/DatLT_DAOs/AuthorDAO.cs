using BussinessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAOs
{
    public class AuthorDAO
    {
        private static AuthorDAO instance;
        public static readonly object instanceLock = new object();

        private AuthorDAO() { }
        public static AuthorDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new AuthorDAO();
                    }
                    return instance;
                }
            }
        }

        public async Task<IEnumerable<Author>> GetAllAsync()
        {
            IEnumerable<Author> list;

            try
            {
                var context = new EBookstoreContext();

                list = await context.Set<Author>().ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return list;
        }

        public async Task<Author?> GetByIdAsync(int id)
        {
            Author? entity;

            try
            {
                var context = new EBookstoreContext();

                entity = await context.Set<Author>().FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return entity;
        }

        public async Task InsertAsync(Author entity)
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

        public async Task UpdateAsync(Author entity)
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

        public async Task DeleteAsync(Author entity)
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
