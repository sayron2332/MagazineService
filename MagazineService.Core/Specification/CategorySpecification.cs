using Ardalis.Specification;
using MagazineService.Core.Dtos.Category;
using MagazineService.Core.Entites;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagazineService.Core.Specification
{
    public class CategorySpecification
    {
        public class GetPurchasedCategories : Specification<AppCategory, CategoryAndQuantityDto>
        {
            public GetPurchasedCategories(int userId)
            {
                Query.Where(c => c.AppProducts
                .Any(p => p.AppPositions.Any(pos => pos.AppOrder.AppClientId == userId)))
                .Select(c => new CategoryAndQuantityDto
                {
                    Name = c.Name,
                    Quantity = c.AppProducts
                        .SelectMany(p => p.AppPositions)
                        .Where(pos => pos.AppOrder.AppClientId == userId)
                        .Sum(pos => pos.ProductCount)
                });

            }
        }
    }
}
