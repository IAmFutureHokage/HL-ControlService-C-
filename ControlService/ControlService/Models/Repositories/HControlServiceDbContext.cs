using ControlService.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace ControlService.Models.Repositories
{
    public class HControlServiceDbContext : DbContext
    {
        public HControlServiceDbContext(DbContextOptions<HControlServiceDbContext> options)
        : base(options)
        {

        }
        public DbSet<HydrologyControl> HydrologyControls { get; set; }
    }
}
