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
    public class AuthorRepo : IAuthorRepo
    {
        public async Task DeleteAsync(Author item)
        {
            await AuthorDAO.Instance.DeleteAsync(item);
        }

        public async Task<IEnumerable<Author>> GetAllAsync()
        {
            return await AuthorDAO.Instance.GetAllAsync();
        }

        public async Task<Author> GetByIdAsync(int id)
        {
            return await AuthorDAO.Instance.GetByIdAsync(id);
        }

        public async Task InsertAsync(Author item)
        {
            await AuthorDAO.Instance.InsertAsync(item);
        }

        public async Task UpdateAsync(Author item)
        {
            await AuthorDAO.Instance.UpdateAsync(item);
        }
    }
}
