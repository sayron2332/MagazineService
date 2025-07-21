using MagazineService.Core.Interfaces;
using MagazineService.Infrastructure.Context;
using MagazineService.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MagazineService.Infrastructure
{
    public static class ServicesExtensions
    {
        public static void AddAppDbContext(this IServiceCollection services, string connString)
        {

            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(connString);

                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });
        }
       
        public static void AddRepository(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        }

    }
}
