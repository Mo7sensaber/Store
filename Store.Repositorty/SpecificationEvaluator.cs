using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Store.Core.Entities;
using Store.Core.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repositorty
{
    public class SpecificationEvaluator<TEntity,TKey> where TEntity : BaseEntity<TKey>
    {
        public static IQueryable<TEntity>  GetQuery(IQueryable<TEntity> inputQuery ,ISpecifications<TEntity,TKey> spac)
        {
            var query = inputQuery;
            if(spac.Criteria is not null)
            {
                query = query.Where(spac.Criteria);
            }
            if(spac.OrderBy is not null)
            {
                query = query.OrderBy(spac.OrderBy);
            }
            if(spac.OrderByDescending is not null)
            {
                query = query.OrderByDescending(spac.OrderByDescending);
            }
            if (spac.IsPaginationEnable)
            {
                query=query.Skip(spac.Skip).Take(spac.Take);
            }
            query= spac.Include.Aggregate(query, (currentQuery, IncludeExpression) => currentQuery.Include(IncludeExpression));
            return query;
        }
    }
}
