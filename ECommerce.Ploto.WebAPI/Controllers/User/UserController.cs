using ECommerce.Ploto.Application.Commands.User.AssignRoleCommand;
using ECommerce.Ploto.Application.Commands.User.LoginUserCookieBaseCommand;
using ECommerce.Ploto.Application.Commands.User.LoginUserTokenBaseCommand;
using ECommerce.Ploto.Application.Commands.User.RegisterUserCommand;
using ECommerce.Ploto.Application.Commands.User.UpsertUserAvater;
using ECommerce.Ploto.Application.Queries.User.GetAllUserQuery;
using ECommerce.Ploto.Common.Dommin.Base;
using ECommerce.Ploto.Common.Extensions;
using ECommerce.Ploto.Common.JobAbstraction.QuartzImplementation.TriggeredJobs;
using ECommerce.Ploto.WebAPI.Controllers.User.RequestDTO;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using StackExchange.Profiling;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace ECommerce.Ploto.WebAPI.Controllers.User
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableRateLimiting("rate-limit-ip-policy")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ITriggeredJobService _jobTriggeredServices;

        public UserController(IMediator mediator, ITriggeredJobService jobTriggeredServices)
        {
            _mediator = mediator;
            _jobTriggeredServices = jobTriggeredServices;
        }

        [HttpGet]
        [Route("users")]
        public async Task<FilteredResult<UserDto>> Users([FromQuery] GetUsersQuery query)
        {
            //await _jobTriggeredServices.FireAndForget(typeof(HelloPorya), "hello pourya", DateTimeOffset.UtcNow, ("name", "pourya"));
                return await _mediator.Send(query);

        }

        [HttpPost]
        [Route("register")]
        //[DisableRateLimiting] // To Disable RateLimit Atrribute
        public async Task<IActionResult> Register([FromBody] RegisterUserCommand command)
        {
                await _mediator.Send(command);
                return Created();

        }

        [HttpPut]
        [Route("user-avatar-upload")]
        public async Task<IActionResult> UpsertAvatar([FromForm] UpsertUserAvaterRequest req)
        {
            var command = new UpsertUserAvatarCommand(req.userId, await req.avatar.GetBytesAsync());
            await _mediator.Send(command);
            return Created();
        }

        [HttpPost]
        [Route("login-cookie-base-auth")]
        public async Task<IActionResult> LoginCookieBase([FromBody] LoginUserCookieBaseCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpPost]
        [Route("assign-role")]
        //[Authorize(Roles = "Admin")]
        public async Task AssignRole([FromBody] AssignRoleCommand command)
        {
            await _mediator.Send(command);
        }


        [HttpPost]
        [Route("login-token-base-auth")]

        public async Task<LoginUserTokenBaseResponse> LoginTokenBase([FromBody] LoginUserTokenBaseCommand command)
        {
            return await _mediator.Send(command);
        }

    }
}


