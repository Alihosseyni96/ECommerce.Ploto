using ECommerce.Ploto.Application.Commands.User.LoginUserCookieBaseCommand.Exception;
using ECommerce.Ploto.Common.AuthenticationAbstraction.TokenBaseAuthenticationImplementation;
using ECommerce.Ploto.Common.CacheAbstraction;
using ECommerce.Ploto.Common.Extensions;
using ECommerce.Ploto.Domain.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Ploto.Application.Commands.User.LoginUserTokenBaseCommand
{
    public class LoginUserTokenBaseCommandHandler : IRequestHandler<LoginUserTokenBaseCommand, LoginUserTokenBaseResponse>
    {
        private readonly IPlotoUnitOfWork _plotoUnitOfWork;
        private readonly ICacheService _cacheService;
        private readonly ITokenBaseAuthenticationService _authService;
        public LoginUserTokenBaseCommandHandler(IPlotoUnitOfWork plotoUnitOfWork, ICacheService cacheService, ITokenBaseAuthenticationService authService)
        {
            _plotoUnitOfWork = plotoUnitOfWork;
            _cacheService = cacheService;
            _authService = authService;
        }

        public async Task<LoginUserTokenBaseResponse> Handle(LoginUserTokenBaseCommand request, CancellationToken cancellationToken)
        {
            var user = await _plotoUnitOfWork.UserRepository
                .SingleOrDdfaultAsync(
                predicate: x => x.PhoneNumber == request.phoneNumber && x.Password == request.password.ComputeSha256Hash(),
                ct: cancellationToken,
                includeThenIncludes: "Role.RolePermissions.Permission");

            var permissions = user.Role.RolePermissions
                .Select(x=> x.Permission.PermissionType)
                .ToArray();

            var permissionConcated = string.Join(",", permissions);



            if (user is null)

                throw new UserNotFoundException();
            var token = _authService.GenerateToken(("UserId", user.Id.ToString()),("Role",user.Role.Name),("Permissions", permissionConcated));
            await _cacheService.SetAsync($"token:{user.Id}", token, TimeSpan.FromDays(30), cancellationToken);

            return new LoginUserTokenBaseResponse(token);
        }
    }
}
