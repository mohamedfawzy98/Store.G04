using Store.G04.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Store.G04.Core.Spectifications
{
    public interface Isepctifation<TEntity , TKey> where TEntity :BaseEntity<TKey>
    {
        // repsent where Func Take TEntity Return bool
        public Expression<Func<TEntity , bool>> critera { get; set; }

        // repsent Include List Func Take TEntity return Object
        public List<Expression<Func<TEntity, object>>> Includes { get; set; }

        // repsent OrderBy List Func Take TEntity return Object
        public Expression<Func<TEntity, object>> OrderBy { get; set; }

        // repsent OrderByDessinding List Func Take TEntity return Object
        public Expression<Func<TEntity, object>> OrderByDessinding { get; set; }

        public int Take { get; set; }
        public int Skip { get; set; }
        public bool IsPaginationEnable { get; set; }

    }
}
