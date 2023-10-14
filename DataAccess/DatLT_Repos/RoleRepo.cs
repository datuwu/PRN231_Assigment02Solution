using BussinessObjects;
using DataAccess.DAOs;
using DataAccess.IRepos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repos
{
    public class RoleRepo : IRoleRepo
    {
        public async Task DeleteAsync(Role item)
        {
            await RoleDAO.Instance.DeleteAsync(item);
        }

        public async Task<IEnumerable<Role>> GetAllAsync()
        {
            return await RoleDAO.Instance.GetAllAsync();
        }

        public async Task<Role> GetByIdAsync(int id)
        {
            return await RoleDAO.Instance.GetByIdAsync(id);
        }

        public async Task InsertAsync(Role item)
        {
            await RoleDAO.Instance.InsertAsync(item);
        }

        public async Task UpdateAsync(Role item)
        {
            await RoleDAO.Instance.UpdateAsync(item);
        }
    }
}
