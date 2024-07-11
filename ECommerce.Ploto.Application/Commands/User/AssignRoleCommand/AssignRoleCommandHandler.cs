using AutoMapper;
using ECommerce.Ploto.Application.Commands.User.AssignRoleCommand.Exception;
using ECommerce.Ploto.Domain.Models.Role;
using ECommerce.Ploto.Domain.UnitOfWork;
using ECommerce.Ploto.Infrastructure.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Ploto.Application.Commands.User.AssignRoleCommand
{
    public class AssignRoleCommandHandler : IRequestHandler<AssignRoleCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AssignRoleCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task Handle(AssignRoleCommand request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.UserRepository
                .SingleOrDdfaultAsync(
                predicate: x => x.Id == request.userId,
                ct: cancellationToken,
                includeThenIncludes: "Role");

            UserNotFoundCheck();


            user!.AddRole(user.Role);

            await _unitOfWork.SaveChangeAsync(cancellationToken);



            //local Function
            void UserNotFoundCheck()
            {
                if (user is null)
                    throw new InvalidUserException();
            }

        }
    }
}
