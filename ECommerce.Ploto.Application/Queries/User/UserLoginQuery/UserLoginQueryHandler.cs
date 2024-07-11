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

namespace ECommerce.Ploto.Application.Queries.User.UserLoginQuery
{
    public class UserLoginQueryHandler : IRequestHandler<UserLoginQuery, UserLoginResponse>
    {
        private readonly ICacheService _cacheService;
        private readonly ITokenBaseAuthenticationService _tokebBaseAuthService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly string _loginCachePrefix;

        public UserLoginQueryHandler(ICacheService cacheService, ITokenBaseAuthenticationService tokebBaseAuthService, IUnitOfWork unitOfWork)
        {
            _cacheService = cacheService;
            _tokebBaseAuthService = tokebBaseAuthService;
            _loginCachePrefix = "login-token-userId-";
            _unitOfWork = unitOfWork;
        }

        public async Task<UserLoginResponse> Handle(UserLoginQuery request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.UserRepository
                .SingleOrDdfaultAsync(
                predicate : u => u.PhoneNumber == request.pboneNumber && u.Password == request.password.ComputeSha256Hash(),
                ct: cancellationToken,
                includeThenIncludes: "UserRoles.Role"
                );

            //if (user is null) throw new InvalidDataException();

            //var roels = user.UserRoles?.Select(r => r.Role).ToList();    
            //var token = _tokebBaseAuthService.GenerateToken(("userid", user.Id.ToString()),);
            return null;


        }
    }
}
