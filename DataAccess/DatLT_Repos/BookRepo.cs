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
    public class BookRepo : IBookRepo
    {
        public async Task DeleteAsync(Book item)
        {
            await BookDAO.Instance.DeleteAsync(item);
        }

        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            return await BookDAO.Instance.GetAllAsync();
        }

        public async Task<Book> GetByIdAsync(int id)
        {
            return await BookDAO.Instance.GetByIdAsync(id);
        }

        public async Task InsertAsync(Book item)
        {
            await BookDAO.Instance.InsertAsync(item);
        }

        public async Task UpdateAsync(Book item)
        {
            await BookDAO.Instance.UpdateAsync(item);
        }
    }
}
