using AutoMapper;
using ECommerce.Ploto.Domain.Models;
namespace ECommerce.Ploto.Application.Commands.User.RegisterUserCommand
{
    public class Mapper: Profile
    {
        public Mapper()
        {
            CreateMap<RegisterUserCommand, Domain.Models.User>()
                .ForMember(x => x.Name, y => y.MapFrom(z => Name.Create(z.FirtsName, z.LastName)))
                .ForMember(x => x.Address, y => y.MapFrom(z => Address.Create(z.City, z.Avenue, z.HouseNO)))
                .ForMember(x => x.HomeNumber, y => y.MapFrom(z => HomeNumber.Create(z.Number, z.CityCode)));

        }
    }
}
