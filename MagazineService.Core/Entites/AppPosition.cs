using MagazineService.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagazineService.Core.Entites
{
    public class AppPosition : IEntity
    {
        public int Id { get; set; }
        public int ProductCount { get; set; }
        public int AppProductId { get; set; }
        public AppProduct AppProduct { get; set; } = null!;
        public int AppOrderId { get; set; }
        public AppOrder AppOrder { get; set; } = null!;
    }
}
