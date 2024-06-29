namespace ECommerce.Ploto.WebAPI.Controllers.User.RequestDTO;

public record UpsertUserAvaterRequest(Guid userId , IFormFile avatar);
