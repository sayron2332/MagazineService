using Ardalis.Specification;
using MagazineService.Core.Dtos.Category;
using MagazineService.Core.Dtos.Client;
using MagazineService.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagazineService.Core.Specification
{
    public class ClientSpecification
    {
        public class GetByDate : Specification<AppClient>
        {
            public GetByDate(DateTime date)
            {
                Query.Where(c => c.BirthdayDate.Date == date.Date);
            }
        }
        public class GetByDay : Specification<AppClient, ClientAndDateDto>
        {
            public GetByDay(int day)
            {
                DateTime date = DateTime.Now.AddDays(-day);
                Query
                     .Where(c => c.AppOrders.Any(o => o.DateOrder >= date))
                     .Select(c => new ClientAndDateDto
                     {
                          Id = c.Id,
                          FullName = $"{c.Name} {c.Surname} {c.MiddleName}",
                          Date = c.AppOrders.Where(o => o.DateOrder >= date)
                                            .Max(o => o.DateOrder)
                     });
            }
        }
    }
}
