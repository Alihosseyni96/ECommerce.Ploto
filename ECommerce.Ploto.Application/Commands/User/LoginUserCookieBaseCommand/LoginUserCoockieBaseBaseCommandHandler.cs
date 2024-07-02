using AutoMapper;
using ECommerce.Ploto.Domain.UnitOfWork;
using MediatR;
using ECommerce.Ploto.Common.Extensions;
using ECommerce.Ploto.Application.Commands.User.LoginUserCookieBaseCommand.Exception;
using ECommerce.Ploto.Common.AuthenticationAbstraction.CookieBaseAuthenticationImpelimentation;
using ECommerce.Ploto.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Ploto.Application.Commands.User.LoginUserCookieBaseCommand;

public class LoginUserCoockieBaseBaseCommandHandler : IRequestHandler<LoginUserCookieBaseCommand>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly ICookieBaseAuthenticationService _cookieBaseAuthService;
    private readonly ApplicationDbContext _db;

    public LoginUserCoockieBaseBaseCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ICookieBaseAuthenticationService cookieBaseAuthService)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _cookieBaseAuthService = cookieBaseAuthService;
    }

    public async Task Handle(LoginUserCookieBaseCommand request, CancellationToken cancellationToken)
    {
        var hashPass = request.password.ComputeSha256Hash();
         
        var user = await _unitOfWork.UserRepository
            .SingleOrDefaultAsync(
            predicate: u=> u.PhoneNumber == request.phoneNumber && u.Password == hashPass,
            ct: cancellationToken,
            include : u=> u.UserRoles);


        IfUserNotFound();
        await LoginUser();





        void IfUserNotFound()
        {
            if (user is null)
                throw new UserNotFoundException();
        }
        async Task LoginUser()
        {
            var roel = user.UserRoles
                .Select(ur=> ur.Role)
                ?.SingleOrDefault()
                ?.Name;

           await  _cookieBaseAuthService.LoginAsync(
                ("UserId",user.Id.ToString()),
                ("Role", roel ?? string.Empty));

        }
    }
}
