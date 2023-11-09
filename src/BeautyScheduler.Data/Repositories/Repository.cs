using BeautyScheduler.Data.DbContexts;
using BeautyScheduler.Data.IRepositories;
using BeautyScheduler.Domain.Commons;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyScheduler.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Auditable
    {
        protected  BeautySchedulerDbContext _dbContext { get; set; }
        private  DbSet<TEntity> _dbSet { get; set; }

        public Repository(BeautySchedulerDbContext beautySchedulerDbContext)
        {
            _dbContext = beautySchedulerDbContext;
            _dbSet = _dbContext.Set<TEntity>();
        }


        public async Task<bool> DeleteAsync(long id)
        {
            var entity = await _dbSet.FirstOrDefaultAsync(e => e.Id == id);
            _dbSet.Remove(entity);
            

            return await _dbContext.SaveChangesAsync()>0;
        }

        public async Task<TEntity> InsertAsync(TEntity entity)
        {
            var result = await _dbSet.AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return result.Entity;
        }

        public IQueryable<TEntity> SelectAll()
            => _dbSet;

        public async Task<TEntity> SelectByIdAsync(long id)
            => await _dbSet.FirstOrDefaultAsync(e => e.Id == id);

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            var entry = _dbSet.Update(entity);
            await _dbContext.SaveChangesAsync();

            return entry.Entity;
        }
    }
}
