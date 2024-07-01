using ECommerce.Ploto.Application.Commands.User.AssignRoleCommand.Exception;
using ECommerce.Ploto.Domain.UnitOfWork;
using MediatR;
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

        public AssignRoleCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(AssignRoleCommand request, CancellationToken cancellationToken)
        {
            var systemRoles = await _unitOfWork.RoleRepository
                .GetAllAsync(cancellationToken);


            var user = await _unitOfWork.UserRepository
                .SingleOrDefaultAsync(
                predicate: u => u.Id == request.userId,
                ct: cancellationToken,
                include: u => u.Roles);

            UserNotFoundCheck();

            user.AddRole(systemRoles.ToArray(), user?.Roles?.ToArray() ?? null, request.roleNames);

            await _unitOfWork.SaveChangeAsync(cancellationToken);




            void UserNotFoundCheck()
            {
                if (user is null)
                    throw new InvalidUserException();
            }

        }
    }
}
