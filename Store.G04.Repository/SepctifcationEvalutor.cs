using Microsoft.EntityFrameworkCore;
using Store.G04.Core.Entites;
using Store.G04.Core.Spectifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.G04.Repository
{
    public class SepctifcationEvalutor<TEntity , TKey> where TEntity :BaseEntity<TKey> 
    {
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputquery , Isepctifation<TEntity,TKey> spec)
        {
            var query = inputquery;

            if(spec.critera is not null)
            {
                query = query.Where(spec.critera);
            }

            if(spec.OrderBy is not null)
            {
                query = query.OrderBy(spec.OrderBy);
            }
            if (spec.OrderByDessinding is not null)
            {
                query = query.OrderByDescending(spec.OrderByDessinding);
            }
            if(spec.IsPaginationEnable)
            {
                query = query.Skip(spec.Skip).Take(spec.Take);
            }
            query = spec.Includes.Aggregate(query, (currentquery, includeexpression) => currentquery.Include(includeexpression));

            return query;
        }
    }
}
