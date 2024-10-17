using Store.Core;
using Store.Core.Entities;
using Store.Core.Repositories.Contract;
using Store.Repositorty.Data.Contexts;
using Store.Repositorty.Repositories;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repositorty
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StoreDBContext _context;
        private Hashtable _repositories;

        public UnitOfWork(StoreDBContext context)
        {
            _context = context;
            _repositories = new Hashtable();
        }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public IGenaricRepository<TEntity, TKey> Repository<TEntity, TKey>() where TEntity : BaseEntity<TKey>
        {
            var type= typeof(TEntity);
            if (!_repositories.ContainsKey(type))
            {
                var repository = new GenaricRepository<TEntity, TKey>(_context);
                _repositories.Add(type, repository);
            }
            return _repositories[type] as IGenaricRepository<TEntity, TKey>;
        }
    }
}
