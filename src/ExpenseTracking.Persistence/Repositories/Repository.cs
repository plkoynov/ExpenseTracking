namespace ExpenseTracking.Persistence.Repositories
{
    using System;
    using System.Threading.Tasks;
    using ExpenseTracking.Application.Interfaces;
    using ExpenseTracking.Domain.Base;
    using ExpenseTracking.Persistence.Data;
    using Microsoft.EntityFrameworkCore;

    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext context;
        protected readonly DbSet<T> dbSet;

        public Repository(AppDbContext context)
        {
            this.context = context;
            this.dbSet = context.Set<T>();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await dbSet.FindAsync(id);
        }

        public async Task AddAsync(T entity)
        {
            await dbSet.AddAsync(entity);
        }

        public async Task UpdateAsync(T entity)
        {
            await dbSet.UpdateAsync(entity);
        }

        public async Task DeleteAsync(T entity)
        {
            await dbSet.RemoveAsync(entity);
        }
    }
}