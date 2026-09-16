using Microsoft.EntityFrameworkCore;

namespace Api_BoxCenter.Infrastructure.Database
{
    public class BoxCenterDbContext: DbContext
    {
        // implementamos DbContext
        public BoxCenterDbContext(DbContextOptions<BoxCenterDbContext> options): base(options) {
        }
    }
}
