using Store.G04.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Store.G04.Core.Spectifications
{
    public class Sepctifcation<TEntity, TKey> : Isepctifation<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        public Expression<Func<TEntity, bool>> critera { get; set; } = null; //  null
        public List<Expression<Func<TEntity, object>>> Includes { get; set ; }  = new List<Expression<Func<TEntity, object>>>(); // null
        public Expression<Func<TEntity, object>> OrderBy { get ; set; } = null;
        public Expression<Func<TEntity, object>> OrderByDessinding { get; set; } = null;
        public int Take { get ; set; }
        public int Skip { get ; set ; }
        public bool IsPaginationEnable { get; set; }

        public Sepctifcation(Expression<Func<TEntity, bool>>  expression)
        {
            critera = expression;
        }

        public Sepctifcation()
        {
           

        }
        public void OrdrByAssc(Expression<Func<TEntity, object>> expression)
        {
            OrderBy = expression;
        }
        public void OrdrByDesse(Expression<Func<TEntity, object>> expression)
        {
            OrderByDessinding = expression;
        }

        public void ApplyPagination(int skip , int take)
        {
            IsPaginationEnable = true;
            Skip = skip;
            Take = take;
        }
    }
}
