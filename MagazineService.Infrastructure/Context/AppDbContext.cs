
using MagazineService.Core.Entites;
using Microsoft.EntityFrameworkCore;


namespace MagazineService.Infrastructure.Context
{
    internal class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
         : base(options)
        {
        }
        public DbSet<AppCategory>AppCategories { get; set; }
        public DbSet<AppClient> AppClients { get; set; }
        public DbSet<AppPosition> AppPositions { get; set; }
        public DbSet<AppOrder> AppOrders { get; set; }
        public DbSet<AppProduct> AppProducts { get; set; }
    }
}
