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
        => await _repository.GetListBySpec(new CategorySpecification.GetPurchasedCategories(Id));
    }
}
