using AutoMapper;

namespace ECommerce.Ploto.Application.Queries.User.GetAllUserQuery
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Domain.Models.User, UserDto>()
                .ForMember(x => x.FullName, y => y.MapFrom(z => $"{z.Name.FirtsName} {z.Name.LastName}"))
                .ForMember(x => x.PhoneNumber, y => y.MapFrom(z => z.PhoneNumber))
                .ForMember(x => x.HomeNumber, y => y.MapFrom(z => $"{z.HomeNumber.CityCode}-{z.HomeNumber.Number}"))
                .ForMember(x => x.Address, y => y.MapFrom(z => $"{z.Address.City}-{z.Address.Avenue}-{z.Address.HouseNO}"))
                .ForPath(x => x.RolePermisssion.Name, y => y.MapFrom(z => z.Role.Name))
                 .AfterMap((src, dast, context) =>
                 {
                     if (src.Role is not null)
                     {
                         var permissionTypes = src.Role.RolePermissions
                         .Select(x => x.Permission.PermissionType)
                         .ToArray();

                         dast.RolePermisssion.PermissionsType = permissionTypes;
                     }
                 })
                ;

        }
    }
}
