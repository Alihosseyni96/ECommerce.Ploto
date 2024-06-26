using AutoMapper;
using ECommerce.Ploto.Domain.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Ploto.Application.Queries.User.GetAllUserQuery
{
    public class GetAllUserQueryHandler : IRequestHandler<GetUsersQuery, IEnumerable<UserDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllUserQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        async Task<IEnumerable<UserDto>> IRequestHandler<GetUsersQuery, IEnumerable<UserDto>>.Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _unitOfWork.UserRepository
                .FindAsync(cancellationToken);

            return _mapper.Map<IEnumerable<UserDto>>(users);

        }
        
    }
}
