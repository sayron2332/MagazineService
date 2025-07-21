using Ardalis.Specification;
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
        public class GetByDay : Specification<AppClient>
        {
            public GetByDay(int day)
            {
                DateTime date = DateTime.Now.AddDays(-day);
                Query.Include(c => c.AppOrders)
                     .Where(c => c.AppOrders.Any(o => o.DateOrder >= date));
            }
        }
    }
}
