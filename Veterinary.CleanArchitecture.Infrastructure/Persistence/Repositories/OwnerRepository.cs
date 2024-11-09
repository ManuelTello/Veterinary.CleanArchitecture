using Microsoft.EntityFrameworkCore;
using Veterinary.CleanArchitecture.Domain.Entities;
using Veterinary.CleanArchitecture.Domain.IRepositories;
using Veterinary.CleanArchitecture.Infrastructure.Data;

namespace Veterinary.CleanArchitecture.Infrastructure.Persistence.Repositories
{
    public class OwnerRepository : IOwnerRepository, IDisposable
    {
        private readonly ApplicationDatabaseContext _context;

        private bool _disposed;

        public OwnerRepository(ApplicationDatabaseContext context)
        {
            this._context = context;
        }

        public async Task<IEnumerable<Owner>> GetAll()
        {
            var owners = await _context.Owners.ToListAsync();
            return owners;
        }

        public async Task<Owner?> GetById(Guid id)
        {
            var owner = await this._context.Owners.FirstOrDefaultAsync(o => o.Id == id);
            return owner;
        }

        public async Task Insert(Owner entity)
        {
            await this._context.Owners.AddAsync(entity);
        }

        public async Task Delete(Guid id)
        {
            var owner = await this._context.Owners.FirstOrDefaultAsync(o => o.Id == id);
            this._context.Owners.Remove(owner!);
        }

        public void Update(Owner entity)
        {
            this._context.Entry(entity).State = EntityState.Modified;
        }

        public async Task SaveChanges()
        {
            await this._context.SaveChangesAsync();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    this._context.Dispose();
                }

                this._disposed = true;
            }
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}