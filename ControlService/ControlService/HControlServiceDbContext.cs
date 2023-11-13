using Microsoft.EntityFrameworkCore;

namespace ControlService
{
    public class HControlServiceDbContext:DbContext
    {
        public HControlServiceDbContext(DbContextOptions<HControlServiceDbContext> options)
        : base(options)
        {
        }
        public DbSet<HydrologyControl> HydrologyControls { get; set; }
    }
}
