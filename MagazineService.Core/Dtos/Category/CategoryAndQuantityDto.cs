using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagazineService.Core.Dtos.Category
{
    public class CategoryAndQuantityDto
    {
        public string Name { get; set; } = string.Empty;
        public int Quantity { get; set; }
    }
}
