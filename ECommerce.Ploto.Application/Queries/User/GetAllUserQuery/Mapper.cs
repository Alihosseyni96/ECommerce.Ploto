using AutoMapper;

namespace ECommerce.Ploto.Application.Queries.User.GetAllUserQuery
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Domain.Models.User, UserDto>()
                .ForMember(x=> x.FullName , y=> y.MapFrom(z=> $"{z.Name.FirtsName} {z.Name.LastName}"))
                .ForMember(x=> x.PhoneNumber , y=> y.MapFrom(z=> z.PhoneNumber))
                .ForMember(x=> x.HomeNumber , y=> y.MapFrom(z=> $"{z.HomeNumber.CityCode}-{z.HomeNumber.Number}"))
                .ForMember(x=> x.Address , y=> y.MapFrom(z=> $"{z.Address.City}-{z.Address.Avenue}-{z.Address.HouseNO}"))
                ;

        }
    }
}
