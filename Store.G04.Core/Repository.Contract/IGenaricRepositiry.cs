using Store.G04.Core.Entites;
using Store.G04.Core.Spectifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.G04.Core.Repository.Contract
{
    public interface IGenaricRepositiry<TEntity , TKey> where TEntity : BaseEntity<TKey>
    {
       Task<IEnumerable<TEntity>> GetAllAsync();

        Task<TEntity> GetAsync(TKey id);

        Task<IEnumerable<TEntity>> GetAllwithspecAsync(Isepctifation<TEntity , TKey> spec);

        Task<TEntity> GetwithspecAsync(Isepctifation<TEntity, TKey> spec);
        Task<int> GetCountAsync(Isepctifation<TEntity, TKey> spec);
        Task AddAsync(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
