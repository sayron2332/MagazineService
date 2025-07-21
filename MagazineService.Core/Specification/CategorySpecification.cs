using Ardalis.Specification;
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
        public class GetPurchasedCategories : Specification<AppCategory>
        {
            public GetPurchasedCategories(int userId)
            {
                Query.Include(c => c.AppProducts).ThenInclude(pro => pro.AppPositions)
                .Where(c => c.AppProducts.Any(p => p.AppPositions
                .Any(pos => pos.AppOrder.AppClientId == userId)));

            }
        }
    }
}
