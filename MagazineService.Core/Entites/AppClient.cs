using MagazineService.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagazineService.Core.Entites
{
    public class AppClient : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } =string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string MiddleName { get; set; } = string.Empty;
        public ICollection<AppOrder> AppOrders { get; set; } = null!;
        public DateTime BirthdayDate { get; set; }
        public DateTime RegisterDate { get; set; }
    }
}
