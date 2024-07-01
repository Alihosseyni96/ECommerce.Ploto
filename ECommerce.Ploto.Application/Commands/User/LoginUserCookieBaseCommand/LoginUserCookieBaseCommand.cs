using MediatR;

namespace ECommerce.Ploto.Application.Commands.User.LoginUserCookieBaseCommand;

public record LoginUserCookieBaseCommand(string phoneNumber , string password) : IRequest;

