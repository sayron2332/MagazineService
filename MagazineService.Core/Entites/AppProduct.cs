using MagazineService.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagazineService.Core.Entites
{
    public class AppProduct : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public double Price { get; set; }
        public string Article { get; set; } = string.Empty;
        public int AppCategoryId { get; set; }
        public AppCategory AppCategory { get; set; } = null!;
        public ICollection<AppPosition> AppPositions { get; set; } = null!;
    }
}
