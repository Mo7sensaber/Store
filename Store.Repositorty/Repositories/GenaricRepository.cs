using Microsoft.EntityFrameworkCore;
using Store.Core.Entities;
using Store.Core.Repositories.Contract;
using Store.Repositorty.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repositorty.Repositories
{
    public class GenaricRepository<TEntity, TKey> : IGenaricRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        private readonly StoreDBContext _context;

        public GenaricRepository(StoreDBContext context)
        {
            _context = context;
        }
        public async Task AddAsync(TEntity entity)
        {
            await _context.AddAsync(entity);
        }

        public void Delete(TEntity id)
        {
            _context.Remove(id);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            if (typeof(TEntity)==typeof(Product))
            {
                return (IEnumerable<TEntity>)await _context.products.Include(P => P.Brand).Include(P => P.Type).ToListAsync();
            }
            return await _context.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetAsync(TKey id)
        {
            if (typeof(TEntity) == typeof(Product))
            {
                return await _context.products.Include(P => P.Brand).Include(P => P.Type).FirstOrDefaultAsync(P=>P.Id==id as int?) as TEntity;
            }
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public void Update(TEntity entity)
        {
            _context.Update(entity);
        }
    }
}
