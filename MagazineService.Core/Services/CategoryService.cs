using MagazineService.Core.Dtos.Category;
using MagazineService.Core.Dtos.Client;
using MagazineService.Core.Entites;
using MagazineService.Core.Interfaces;
using MagazineService.Core.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagazineService.Core.Services
{
    public class CategoryService(IRepository<AppCategory> repository) : ICategoryService
    {
        private readonly IRepository<AppCategory> _repository = repository;
        public async Task<IEnumerable<CategoryAndQuantityDto>> GetListPopularCategoryByUserId(int Id)
        {
            var categories = await _repository
                .GetListBySpec(new CategorySpecification.GetPurchasedCategories(Id));

            IEnumerable<CategoryAndQuantityDto> result = categories.Select(c => new CategoryAndQuantityDto
            {
                Name = c.Name,
                Quantity = c.AppProducts.SelectMany(p => p.AppPositions)
                .Sum(pos => pos.ProductCount)
            });

            return result;
        }

    }
}
