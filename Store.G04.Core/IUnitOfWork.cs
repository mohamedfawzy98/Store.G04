using Store.G04.Core.Entites;
using Store.G04.Core.Repository.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.G04.Core
{
    public interface IUnitOfWork
    {
        /// to save changes
        
        Task<int> CompleteAsync();

        IGenaricRepositiry<TEntity, Tkey> Repositiry<TEntity, Tkey>() where TEntity : BaseEntity<Tkey>;
    }
}
