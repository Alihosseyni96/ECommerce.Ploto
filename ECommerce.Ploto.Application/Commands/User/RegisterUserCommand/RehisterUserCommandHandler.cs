using AutoMapper;
using ECommerce.Ploto.Domain.Models;
using ECommerce.Ploto.Domain.UnitOfWork;
using MediatR;

namespace ECommerce.Ploto.Application.Commands.User.RegisterUserCommand
{
    public class RehisterUserCommandHandler : IRequestHandler<RegisterUserCommand>
    {
        private readonly IMapper _mapper;
        private readonly IPlotoUnitOfWork _uw;

        public RehisterUserCommandHandler(IMapper mapper, IPlotoUnitOfWork uw)
        {
            _mapper = mapper;
            _uw = uw;
        }

        public async Task Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var user = Domain.Models.User
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
