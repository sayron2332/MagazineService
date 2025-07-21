
using Microsoft.Extensions.DependencyInjection;
using MagazineService.Core.Entites;
using MagazineService.Infrastructure.Context;
namespace MagazineService.Infrastructure.Helpers
{
    public static class SeedData
    {
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<AppDbContext>();

            if (!context.AppClients.Any())
            {
                var client = new AppClient
                {
                    Name = "Nazar",
                    Surname = "Kurylovych",
                    MiddleName = "Mykolayovych",
                    BirthdayDate = DateTime.Now.AddDays(-1000),
                    RegisterDate = DateTime.Now,
                };
                var client2 = new AppClient
                {
                    Name = "Max",
                    Surname = "Buhrym",
                    MiddleName = "Valeriyovych",
                    BirthdayDate = DateTime.Now.AddDays(-900),
                    RegisterDate = DateTime.Now,
                };
                // Створення користувача
                await context.AppClients.AddAsync(client);
                await context.AppClients.AddAsync(client2);
                await context.SaveChangesAsync();

            }
            if (!context.AppCategories.Any())
            {
                await context.AppCategories.AddAsync(new AppCategory { Name = "Strike" });
                await context.AppCategories.AddAsync(new AppCategory { Name = "Fantasy" });
                await context.AppCategories.AddAsync(new AppCategory { Name = "Horor" });
                await context.SaveChangesAsync();
            }
            if (!context.AppProducts.Any())
            {
                await context.AppProducts.AddAsync(new AppProduct
                {
                    Name = "Honey",
                    AppCategoryId = 1,
                    Article = "honey-art",
                    Price = 120,

                });
                await context.AppProducts.AddAsync(new AppProduct
                {
                    Name = "Tomato",
                    AppCategoryId = 2,
                    Article = "tomato-art",
                    Price = 90,

                });
                await context.AppProducts.AddAsync(new AppProduct
                {
                    Name = "Chees",
                    AppCategoryId = 3,
                    Article = "Chees-art",
                    Price = 200,

                });
                await context.AppProducts.AddAsync(new AppProduct
                {
                    Name = "cucamber",
                    AppCategoryId = 1,
                    Article = "cucamber-art",
                    Price = 5,
                });

                await context.SaveChangesAsync();

            }
            if (!context.AppOrders.Any())
            {
                await context.AppOrders.AddAsync(new AppOrder
                {
                    AppClientId = 1,
                    DateOrder = DateTime.Now,
                    Number = "tomatdawdada",
                    TotalSum = 120,
                });
                await context.AppOrders.AddAsync(new AppOrder
                {
                    AppClientId = 1,
                    DateOrder = DateTime.Now.AddDays(-6),
                    Number = "htfkdtmidr",
                    TotalSum = 500,
                });
                await context.AppOrders.AddAsync(new AppOrder
                {
                    AppClientId = 2,
                    DateOrder = DateTime.Now.AddDays(-10),
                    Number = "vndbhhvd",
                    TotalSum = 310,
                });
                await context.SaveChangesAsync();
            }
            if (!context.AppPositions.Any())
            {
                await context.AppPositions.AddAsync(new AppPosition
                {
                    AppProductId = 1,
                    AppOrderId = 1,
                    ProductCount = 5
                });
                await context.AppPositions.AddAsync(new AppPosition
                {
                    AppProductId = 3,
                    AppOrderId = 2,
                    ProductCount = 6
                });
                await context.AppPositions.AddAsync(new AppPosition
                {
                    AppProductId = 2, 
                    AppOrderId = 3, 
                    ProductCount = 3
                });
                await context.SaveChangesAsync();
            }
        }
    }
}