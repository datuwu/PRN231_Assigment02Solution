using BussinessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAOs
{
    public class RoleDAO
    {
        private static RoleDAO instance;
        public static readonly object instanceLock = new object();

        private RoleDAO() { }
        public static RoleDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new RoleDAO();
                    }
                    return instance;
                }
            }
        }

        public async Task<IEnumerable<Role>> GetAllAsync()
        {
            IEnumerable<Role> list;

            try
            {
                var context = new EBookstoreContext();

                list = await context.Set<Role>().ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return list;
        }

        public async Task<Role?> GetByIdAsync(int id)
        {
            Role? entity;

            try
            {
                var context = new EBookstoreContext();

                entity = await context.Set<Role>().FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return entity;
        }

        public async Task InsertAsync(Role entity)
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

        public async Task UpdateAsync(Role entity)
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

        public async Task DeleteAsync(Role entity)
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
