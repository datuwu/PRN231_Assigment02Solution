using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.IRepos
{
    public interface IGenericRepository<TEntity>
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task InsertAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
    }

    
    public interface IGenericOneKeyRepository<TEntity> : IGenericRepository<TEntity>
    {
        Task<TEntity> GetByIdAsync(int id);
    }

    public interface IGenericTwoKeyRepository<TEntity> : IGenericRepository<TEntity>
    {
        Task<TEntity> GetByIdAsync(int id1, int id2);
    }
}
