using AutoMapper;
using ECommerce.Ploto.Common.Dommin.Base;
using ECommerce.Ploto.Domain.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Ploto.Application.Queries.User.GetAllUserQuery
{
    public class GetAllUserQueryHandler : IRequestHandler<GetUsersQuery, FilteredResult<UserDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllUserQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<FilteredResult<UserDto>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _unitOfWork
                 .UserRepository.FindByFilterPaginatedAsync(cancellationToken, request,"UserRoles");

            //users.Data = _mapper.Map<List<UserDto>>(users);
            //return users;
            return new FilteredResult<UserDto>()
            {
                CurrenPage = users.CurrenPage,
                TotalPage = users.TotalPage,
                //Data = _mapper.Map<List<UserDto>>(users)  
                Data = users.Data.Select(x => new UserDto()
                {
                    FullName = $"{x.Name.FirtsName}{x.Name.LastName}",
                    Address = $"{x.Address.City}-{x.Address.City}-{x.Address.Avenue}",
                    HomeNumber = $"{x.HomeNumber.CityCode}-{x.HomeNumber.Number}",
                    PhoneNumber = x.PhoneNumber
                })
            };
        }
    }
}
