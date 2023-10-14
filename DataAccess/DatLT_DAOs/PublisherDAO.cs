using BussinessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAOs
{
    public class PublisherDAO
    {
        private static PublisherDAO instance;
        public static readonly object instanceLock = new object();

        private PublisherDAO() { }
        public static PublisherDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new PublisherDAO();
                    }
                    return instance;
                }
            }
        }

        public async Task<IEnumerable<Publisher>> GetAllAsync()
        {
            IEnumerable<Publisher> list;

            try
            {
                var context = new EBookstoreContext();

                list = await context.Set<Publisher>().ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return list;
        }

        public async Task<Publisher?> GetByIdAsync(int id)
        {
            Publisher? entity;

            try
            {
                var context = new EBookstoreContext();

                entity = await context.Set<Publisher>().FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return entity;
        }

        public async Task InsertAsync(Publisher entity)
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

        public async Task UpdateAsync(Publisher entity)
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

        public async Task DeleteAsync(Publisher entity)
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
