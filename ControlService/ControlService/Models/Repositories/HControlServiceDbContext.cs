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


        //public HControlServiceDbContext(string connectionString)
        //: base(GetDbContextOptions(connectionString))
        //{
        //}

        //private static DbContextOptions<HControlServiceDbContext> GetDbContextOptions(string connectionString)
        //{
        //    return new DbContextOptionsBuilder<HControlServiceDbContext>()
        //        .UseNpgsql(connectionString)
        //        .Options;
        //}

        //public DbSet<HydrologyControl> HydrologyControls { get; set; }
    }
}
