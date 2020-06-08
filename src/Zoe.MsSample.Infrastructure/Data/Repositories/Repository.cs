using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Zoe.Data.Repositories;
using Zoe.Domain.Models;
using Zoe.MsSample.Infrastructure.Data.Context;

namespace Zoe.MsSample.Infrastructure.Data.Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity<TEntity>, IAggregateRoot
    {
        private bool _disposed;

        protected readonly MsSampleDbContext Context;
        protected readonly DbSet<TEntity> DbSet;

        public Repository(MsSampleDbContext context)
        {
            this.Context = context ?? throw new ArgumentNullException(nameof(context));
            this.DbSet = this.Context.Set<TEntity>();
        }

        public void Add(TEntity obj) => this.DbSet.Add(obj);
        public void Update(TEntity obj) => this.DbSet.Update(obj);
        public void Remove(Guid id) => this.DbSet.Remove(this.DbSet.Find(id));

        public async Task<TEntity> GetByIdAsync(Guid id) => await this.DbSet.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

        public async Task<int> SaveChangesAsync()
        {
            return await this.Context.SaveChangesAsync();
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (this._disposed) return;

            if (disposing)
            {
                this.Context.Dispose();
            }

            this._disposed = true;
        }
    }
}
