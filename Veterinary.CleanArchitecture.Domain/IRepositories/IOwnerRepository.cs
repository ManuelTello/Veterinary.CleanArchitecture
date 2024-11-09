using Veterinary.CleanArchitecture.Domain.Entities;

namespace Veterinary.CleanArchitecture.Domain.IRepositories
{
    public interface IOwnerRepository
    {
        Task<IEnumerable<Owner>> GetAll();

        Task<Owner?> GetById(Guid id);
        
        Task Insert(Owner entity);
        
        Task Delete(Guid id);
        
        void Update(Owner entity);

        Task SaveChanges();
    }
}

