using AutoMapper;
using ECommerce.Ploto.Common.CacheAbstraction;
using ECommerce.Ploto.Domain.Models;
using ECommerce.Ploto.Domain.UnitOfWork;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace ECommerce.Ploto.Application.Commands.User.RegisterUserCommand
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand>
    {
        private readonly IMapper _mapper;
        private readonly IPlotoUnitOfWork _uw;
        private readonly string _defaultRole;
        private readonly IConfiguration _configuration;
        private readonly ICacheService _redisCacehService;

        public RegisterUserCommandHandler(IMapper mapper, IPlotoUnitOfWork uw, IConfiguration configuration, ICacheService redisCacehService)
        {
            _mapper = mapper;
            _uw = uw;
            _configuration = configuration;
            _defaultRole = _configuration["DefaultRole"]!;
            _redisCacehService = redisCacehService;
        }

        public async Task Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {

            var user = Domain.Models.User
                .Create(Name.Create(request.FirtsName, request.LastName),
                request.PhoneNumber,
                request.Password,
                HomeNumber.Create(request.Number, request.CityCode),
                Address.Create(request.City, request.Avenue, request.HouseNO));

            var userRole = await _uw.RoleRepository
                .SingleOrDdfaultAsync(r => r.Name == "User");

            user.AddRole(userRole);

            await _uw.UserRepository.AddAsync(user, cancellationToken);

            await _uw.SaveChangeAsync(cancellationToken);

        }
    }
}
