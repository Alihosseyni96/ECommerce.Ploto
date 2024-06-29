using MediatR;

namespace ECommerce.Ploto.Application.Commands.User.UpsertUserAvater;

public record UpsertUserAvatarCommand(Guid userId , byte[] avater) : IRequest;

