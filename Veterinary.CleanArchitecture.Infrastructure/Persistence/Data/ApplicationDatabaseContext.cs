using Microsoft.EntityFrameworkCore;

namespace Veterinary.CleanArchitecture.Infrastructure.Data
{
    public class ApplicationDatabaseContext:DbContext
    {
        public ApplicationDatabaseContext(DbContextOptions<ApplicationDatabaseContext> options) : base(options) { }
    }
}

