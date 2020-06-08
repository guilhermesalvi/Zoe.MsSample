using System;
using System.Threading.Tasks;
using Zoe.Data.UoW;
using Zoe.MsSample.Infrastructure.Data.Context;

namespace Zoe.MsSample.Infrastructure.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private bool _disposed;
        private readonly MsSampleDbContext _context;

        public UnitOfWork(MsSampleDbContext context)
        {
            this._context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<bool> CommitAsync()
        {
            return await this._context.SaveChangesAsync() > 0;
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
                this._context.Dispose();
            }

            this._disposed = true;
        }
    }
}
