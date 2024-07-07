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
            var systemRoles = await _unitOfWork.RoleRepository
                .GetAllAsync(cancellationToken);

            var roleToAdd = systemRoles
                .Where(x=> request.roleIds.Contains(x.Id))
                .ToArray();



            var user = await _unitOfWork.UserRepository
                .SingleOrDdfaultAsync(
                predicate :  x => x.Id == request.userId,
                ct: cancellationToken,
                includeThenIncludes: "UserRoles.Role");


            var userEixtedRole = user!.UserRoles?
                .Select(ur=> ur.Role)
                .ToArray();   

            UserNotFoundCheck();


            user!.AddRole(systemRoles.ToArray(), userEixtedRole, roleToAdd);

                await _unitOfWork.SaveChangeAsync(cancellationToken);



            void UserNotFoundCheck()
            {
                if (user is null)
                    throw new InvalidUserException();
            }

        }
    }
}
