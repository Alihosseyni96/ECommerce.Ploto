using AutoMapper;
using ECommerce.Ploto.Common.CacheAbstraction;
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
        private readonly IPlotoUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ICacheService _redisCacheServicel;

        public GetAllUserQueryHandler(IPlotoUnitOfWork unitOfWork, IMapper mapper, ICacheService redisCacheServicel)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _redisCacheServicel = redisCacheServicel;
        }

        public async Task<FilteredResult<UserDto>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var baseKey = "rider-location:";
            var zoneid1 = 123;
            var riderid1 = 1;
            var riderid2 = 2;
            var riderid3 = 3;

            var zone2 = 234;
            var riderid4 = 3;
            var riderid5 = 4;

            await _redisCacheServicel.SetAsync($"{baseKey}zoneid:{zoneid1}:riderid:{riderid1}", "pourya", TimeSpan.FromHours(1));
            await _redisCacheServicel.SetAsync($"{baseKey}zoneid:{zoneid1}:riderid:{riderid2}", "pourya2", TimeSpan.FromHours(1));
            await _redisCacheServicel.SetAsync($"{baseKey}zoneid:{zoneid1}:riderid:{riderid3}", "pourya3", TimeSpan.FromHours(1));
            await _redisCacheServicel.SetAsync($"{baseKey}zoneid:{zone2}:riderid:{riderid4}", "pourya4", TimeSpan.FromHours(1));
            await _redisCacheServicel.SetAsync($"{baseKey}zoneid:{zone2}:riderid:{riderid5}", "pourya5", TimeSpan.FromHours(1));


            var t = await _redisCacheServicel.GetKeyPatternAsync<string>($"{baseKey}zoneid:{zone2}:*");


            await _redisCacheServicel.RemoveKeyPatternAsync($"{baseKey}zoneid:{zoneid1}:*");


            var users = await _unitOfWork
                 .UserRepository.FindByFilterPaginatedAsync(cancellationToken, request, "UserRoles.Role");

            return new FilteredResult<UserDto>()
            {
                CurrenPage = users.CurrenPage,
                TotalPage = users.TotalPage,
                Data = _mapper.Map<List<UserDto>>(users.Data)
            };


        }
    }




}
