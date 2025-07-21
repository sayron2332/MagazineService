using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagazineService.Core.Dtos.Client
{
    public class ClientAndDateDto
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public DateTime Date { get; set; }
    }
}
