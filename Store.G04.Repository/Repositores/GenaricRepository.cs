using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Store.G04.Core.Entites;
using Store.G04.Core.Repository.Contract;
using Store.G04.Core.Spectifications;
using Store.G04.Repository.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.G04.Repository.Repositores
{
    public class GenaricRepository<TEntity, TKey> : IGenaricRepositiry<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        private readonly StoreDbContext _context;

        public GenaricRepository(StoreDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            if(typeof(TEntity) == typeof(Product))
            {
              return (IEnumerable<TEntity>) await _context.Products.Include(p => p.Brand).Include(p => p.Type).ToListAsync();
            }
          return await _context.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetAsync(TKey id)
        {
            if (typeof(TEntity) == typeof(Product))
            {
               // return await _context.Products.Include(p => p.Brand).Include(p => p.Type).FirstOrDefaultAsync(p => p.Id == id as int ?) as TEntity;
                return await _context.Products.Where(p => p.Id == id as int?).Include(p => p.Brand).Include(p => p.Type).FirstOrDefaultAsync() as TEntity;
            }
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public async Task AddAsync(TEntity entity)
        {
           await _context.AddAsync(entity);
        }

        public void Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
        }       

        public void Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        public async Task<IEnumerable<TEntity>> GetAllwithspecAsync(Isepctifation<TEntity, TKey> spec)
        {
            return await ApplySpectifation(spec).ToListAsync();
        }

        public async Task<TEntity> GetwithspecAsync(Isepctifation<TEntity, TKey> spec)
        {
            return await ApplySpectifation(spec).FirstOrDefaultAsync();
        }

        private  IQueryable<TEntity> ApplySpectifation(Isepctifation<TEntity, TKey> spec)
        {
            return  SepctifcationEvalutor<TEntity, TKey>.GetQuery(_context.Set<TEntity>(), spec);
        }

        public async Task<int> GetCountAsync(Isepctifation<TEntity, TKey> spec)
        {
            return await ApplySpectifation(spec).CountAsync();
        }
    }
}
