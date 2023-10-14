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
    public class PublisherRepo : IPublisherRepo
    {
        public async Task DeleteAsync(Publisher item)
        {
            await PublisherDAO.Instance.DeleteAsync(item);
        }

        public async Task<IEnumerable<Publisher>> GetAllAsync()
        {
            return await PublisherDAO.Instance.GetAllAsync();
        }

        public async Task<Publisher> GetByIdAsync(int id)
        {
            return await PublisherDAO.Instance.GetByIdAsync(id);
        }

        public async Task InsertAsync(Publisher item)
        {
            await PublisherDAO.Instance.InsertAsync(item);
        }

        public async Task UpdateAsync(Publisher item)
        {
            await PublisherDAO.Instance.UpdateAsync(item);
        }
    }
}
