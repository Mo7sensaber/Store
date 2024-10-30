using Store.Core.Entities;
using Store.Core.Entities.Order;
using Store.Core.Specifications;
using Store.Core.Specifications.OrdersSpes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Core.Repositories.Contract
{
    public interface IGenaricRepository<TEntity,TKey> where TEntity : BaseEntity<TKey>
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetAsync(TKey id);
        Task<IEnumerable<TEntity>> GetAllWithSpacAsync(ISpecifications<TEntity,TKey> spac);
        Task<TEntity> GetWithSpacAsync(ISpecifications<TEntity, TKey> spac);
        Task<int> GetCountAsync(ISpecifications<TEntity, TKey> spac);
        Task AddAsync(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity id);
        
    }
}
