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
    public class GetAllUserQueryHandler : IRequestHandler<GetUsersQuery, FilteredResult>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllUserQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<FilteredResult> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _unitOfWork
                 .UserRepository.FindByFilterPaginatedAsync(cancellationToken, request);

            return users;
        }
    }
}
