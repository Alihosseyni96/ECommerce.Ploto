using AutoMapper;
using ECommerce.Ploto.Domain.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Ploto.Application.Queries.User.GetAllUserQuery
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Domain.Models.User.User, UserDto>()
                .ForMember(x=> x.FullName , y=> y.MapFrom(z=> $"{z.Name.FirtsName} {z.Name.LastName}"));
        }
    }
}
