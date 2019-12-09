using AutoMapper;
using MvcPIN.Models;
using MvcPIN.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcPIN.Web
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<PIN, PinViewModel>().ReverseMap();
            CreateMap<PIN, PinsViewModel>().ReverseMap();
        }
    }
}
