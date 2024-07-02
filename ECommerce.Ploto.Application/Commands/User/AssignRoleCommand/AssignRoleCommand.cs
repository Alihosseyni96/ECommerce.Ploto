using MediatR;

namespace ECommerce.Ploto.Application.Commands.User.AssignRoleCommand;

public record AssignRoleCommand(Guid userId, Guid[] roleIds) : IRequest;


