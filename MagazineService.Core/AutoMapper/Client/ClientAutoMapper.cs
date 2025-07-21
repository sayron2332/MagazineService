using AutoMapper;
using MagazineService.Core.Dtos.Client;
using MagazineService.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagazineService.Core.AutoMapper.Client
{
    public class ClientAutoMapper : Profile
    {
        public ClientAutoMapper()
        {
            CreateMap<AppClient, ClientDto>();
            CreateMap<AppClient, ClientAndDateDto>();
        }
    }
}
