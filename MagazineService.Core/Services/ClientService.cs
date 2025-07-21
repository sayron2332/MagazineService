using AutoMapper;
using MagazineService.Core.Dtos.Client;
using MagazineService.Core.Entites;
using MagazineService.Core.Interfaces;
using MagazineService.Core.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MagazineService.Core.Services
{
    public class ClientService : IClientService
    {
        private readonly IRepository<AppClient> _repository;
        private readonly IMapper _mapper;
        public ClientService(IRepository<AppClient> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ClientDto>> GetCustommersWithBirthday(DateTime date)
        {
            var customers = await _repository.GetListBySpec(new ClientSpecification.GetByDate(date));
            return customers.Select(c => _mapper.Map<ClientDto>(c));
        }

        public async Task<IEnumerable<ClientAndDateDto>> GetLastCustomersByDayOrder(int day)
        {
            var customers = await _repository.GetListBySpec(new ClientSpecification.GetByDay(day));

            var result = customers.Select(x => new ClientAndDateDto
            {
                Id = x.Id,
                FullName = x.Name + " " + x.Surname + " " + x.MiddleName,
                Date = x.AppOrders.Max(o => o.DateOrder)
            });

            return result;
        }
    }
}
