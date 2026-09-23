using Api_BoxCenter.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api_BoxCenter.Infrastructure.Database
{
    public class BoxCenterDbContext: DbContext
    {
        // implementamos DbContext
        // esto si lo entiendo
        public BoxCenterDbContext(DbContextOptions<BoxCenterDbContext> options): base(options) {
        }

        // nos permite tener acceso a los registros del usuario   y empresa mediante este dbContext
        // nos permitira realizar consultas LINQ a SQL segun la el contexto de la entidad   
        public DbSet<Empresa> Empresas => Set<Empresa>();
        public DbSet<Usuario> Usuarios => Set<Usuario>();
        public DbSet<Sessiones> Sessiones => Set<Sessiones>();
        public DbSet<ApiKey> ApiKey => Set<ApiKey>();



        // en objeto ModelBuilder nos permite configurar el modelo completo global
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            // ApplyConfigurationsFromAssambly nos permite mapear toda las configuraciones de EF Core existentes 
            // en el ensamblado y aplicarlas    
            modelBuilder.ApplyConfigurationsFromAssembly(
                typeof(BoxCenterDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
