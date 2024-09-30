using Store.G04.Core;
using Store.G04.Core.Entites;
using Store.G04.Core.Repository.Contract;
using Store.G04.Repository.Data.Context;
using Store.G04.Repository.Repositores;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Store.G04.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StoreDbContext _context;
        private Hashtable _repositories;
        public UnitOfWork(StoreDbContext context)
        {
            _context = context;
            _repositories = new Hashtable();
        }
        public async Task<int> CompleteAsync() => await _context.SaveChangesAsync();

        public IGenaricRepositiry<TEntity, Tkey> Repositiry<TEntity, Tkey>() where TEntity : BaseEntity<Tkey>
        {
            var type = typeof(TEntity).Name;
            if(! _repositories.ContainsKey(type))
            {
                var repository = new GenaricRepository<TEntity, Tkey>(_context);

                _repositories.Add(type, repository);
            }

               return _repositories[type] as IGenaricRepositiry<TEntity, Tkey>;

        }
    }
}
