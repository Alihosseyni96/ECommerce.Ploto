using AutoMapper;
using ECommerce.Ploto.Domain.Models.User;
using ECommerce.Ploto.Domain.Models.User.ValueObject;
using ECommerce.Ploto.Domain.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Ploto.Application.Commands.User.RegisterUserCommand
{
    public class RehisterUserCommandHandler : IRequestHandler<RegisterUserCommand>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uw;

        public RehisterUserCommandHandler(IMapper mapper, IUnitOfWork uw)
        {
            _mapper = mapper;
            _uw = uw;
        }

        public async Task Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var user = Domain.Models.User.User
                .Create(Name.Create(request.FirtsName, request.LastName),
                request.PhoneNumber,
                request.Password,
                HomeNumber.Create(request.Number, request.CityCode),
                Address.Create(request.City, request.Avenue, request.HouseNO));

            await _uw.UserRepository.AddAsync(user , cancellationToken);

            await _uw.SaveChangeAsync(cancellationToken);

        }
    }
}
