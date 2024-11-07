using Microsoft.EntityFrameworkCore;
using Veterinary.CleanArchitecture.Domain.Entities;

namespace Veterinary.CleanArchitecture.Infrastructure.Data
{
    public class ApplicationDatabaseContext:DbContext
    {
        public ApplicationDatabaseContext(DbContextOptions<ApplicationDatabaseContext> options) : base(options) { }
        
        public DbSet<Owner> Owners { get; set; }
    }
}

