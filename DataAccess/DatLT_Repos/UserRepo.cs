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
    public class UserRepo : IUserRepo
    {
        public async Task DeleteAsync(User item)
        {
            await UserDAO.Instance.DeleteAsync(item);
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await UserDAO.Instance.GetAllAsync();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await UserDAO.Instance.GetByIdAsync(id);
        }

        public async Task InsertAsync(User item)
        {
            await UserDAO.Instance.InsertAsync(item);
        }

        public async Task UpdateAsync(User item)
        {
            await UserDAO.Instance.UpdateAsync(item);
        }
    }
}
