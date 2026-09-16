using Api_BoxCenter.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api_BoxCenter.Infrastructure.Database
{
    public class BoxCenterDbContext: DbContext
    {
        // implementamos DbContext
        public BoxCenterDbContext(DbContextOptions<BoxCenterDbContext> options): base(options) {
        }

        public DbSet<Empresa> Empresas => Set<Empresa>();
        public DbSet<Usuario> Usuarios => Set<Usuario>();
    }
}
