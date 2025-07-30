using MagazineService.Core.Dtos.Category;
using MagazineService.Core.Entites;
using MagazineService.Core.Interfaces;
using MagazineService.Core.Services;
using MagazineService.Core.Specification;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagazineService.Tests.Services
{
    public class CategoryServiceTests
    {
        private readonly Mock<IRepository<AppCategory>> _repoMock;
        private readonly CategoryService _categoryService;

        public CategoryServiceTests()
        {
            _repoMock = new Mock<IRepository<AppCategory>>();
            _categoryService = new CategoryService(_repoMock.Object);
        }

        [Fact]
        public async Task GetListPopularCategoryByUserId_ReturnsMappedCategories()
        {
          
            var userId = 1;

            var categories = new List<CategoryAndQuantityDto>
            {
               new CategoryAndQuantityDto { Name = "Category 1", Quantity = 10 },
               new CategoryAndQuantityDto { Name = "Category 2", Quantity = 5 }
            };


            _repoMock.Setup(r => r.GetListBySpec(It.IsAny<CategorySpecification.GetPurchasedCategories>()))
            .ReturnsAsync(categories.Select(c => new CategoryAndQuantityDto
            {
                Name = c.Name,
                Quantity = c.Quantity,
            }).ToList());

            var result = await _categoryService.GetListPopularCategoryByUserId(userId);

            Assert.NotNull(result);
            var resultList = result.ToList();
            Assert.Equal(categories.Count, resultList.Count);

            for (int i = 0; i < categories.Count; i++)
            {
                Assert.Equal(categories[i].Name, resultList[i].Name);
                Assert.Equal(categories[i].Quantity, resultList[i].Quantity);
            }
            _repoMock.Verify(r => r.GetListBySpec(It.IsAny<CategorySpecification.GetPurchasedCategories>()), Times.Once);
        }
    }
}
