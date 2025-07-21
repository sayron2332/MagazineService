using MagazineService.Core.Dtos.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagazineService.Core.Interfaces
{
    public interface IClientService
    {
        public Task<IEnumerable<ClientDto>> GetCustommersWithBirthday(DateTime date);
        public Task<IEnumerable<ClientAndDateDto>> GetLastCustomersByDayOrder(int day);


    }
}
