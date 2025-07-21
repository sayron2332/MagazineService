using MagazineService.Core.Dtos.Category;
using MagazineService.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagazineService.Core.Interfaces
{
    public interface ICategoryService
    {
        public Task<IEnumerable<CategoryAndQuantityDto>> GetListPopularCategoryByUserId(int Id);
    }
}
