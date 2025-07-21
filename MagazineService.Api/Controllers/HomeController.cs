using MagazineService.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MagazineService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController(IClientService clientService, ICategoryService categoryService) : ControllerBase
    {
        private readonly IClientService _clientService = clientService;
        private readonly ICategoryService _categoryService = categoryService;
        [HttpGet("customers-with-birthday")]
        public async Task<IActionResult> GetCustomersWithBirthday(DateTime date)
        {
            return Ok(await _clientService.GetCustommersWithBirthday(date));
        }

        [HttpGet("last-customers")]
        public async Task<IActionResult> GetCustomersByLastOrderDays(int day)
        {
            return Ok(await _clientService.GetLastCustomersByDayOrder(day));
        }
        [HttpGet("last-clients-categories")]
        public async Task<IActionResult> GetLastCategoriesByClientId(int Id)
        {
            return Ok(await _categoryService.GetListPopularCategoryByUserId(Id));
        }
    }
}
