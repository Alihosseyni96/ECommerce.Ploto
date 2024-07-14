using AutoMapper;
using ECommerce.Ploto.Application.Commands.User.AssignRoleCommand.Exception;
using ECommerce.Ploto.Domain.UnitOfWork;
using MediatR;

namespace ECommerce.Ploto.Application.Commands.User.AssignRoleCommand
{
    public class AssignRoleCommandHandler : IRequestHandler<AssignRoleCommand>
    {
        private readonly IPlotoUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AssignRoleCommandHandler(IPlotoUnitOfWork unitOfWork, IMapper mapper)
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
