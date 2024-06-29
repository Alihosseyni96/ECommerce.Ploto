using AutoMapper;
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
            var user = _mapper.Map<Domain.Models.User.User>(request);

            await _uw.UserRepository.AddAsync(user , cancellationToken);

            await _uw.SaveChangeAsync(cancellationToken);

        }
    }
}
