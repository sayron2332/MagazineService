using MagazineService.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagazineService.Core.Entites
{
    public class AppOrder : IEntity
    {
        public int Id { get; set; }
        public string Number { get; set; } = string.Empty; 
        public DateTime DateOrder { get; set; }
        public double TotalSum { get; set; }
        public ICollection<AppPosition> AppPositions { get; set; } = null!;
        public AppClient AppClient { get; set; } = null!;
        public int AppClientId { get; set; }
    }
}
