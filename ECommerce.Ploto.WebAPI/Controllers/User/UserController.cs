using ECommerce.Ploto.Application.Commands.User.AssignRoleCommand;
using ECommerce.Ploto.Application.Commands.User.LoginUserCookieBaseCommand;
using ECommerce.Ploto.Application.Commands.User.RegisterUserCommand;
using ECommerce.Ploto.Application.Commands.User.UpsertUserAvater;
using ECommerce.Ploto.Application.Queries.User.GetAllUserQuery;
using ECommerce.Ploto.Common.Dommin.Base;
using ECommerce.Ploto.Common.Extensions;
using ECommerce.Ploto.WebAPI.Controllers.User.RequestDTO;
using MediatR;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Runtime.InteropServices;

namespace ECommerce.Ploto.WebAPI.Controllers.User
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("users")]
        public async Task<FilteredResult> Users([FromQuery] GetUsersQuery query)
        {
            var res = await _mediator.Send(new GetUsersQuery());
            return res;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserCommand command)
        {
            await _mediator.Send(command);
            return Created();
        }

        [HttpPut]
        [Route("user-avatar-upload")]
        public async Task<IActionResult> UpsertAvatar([FromForm] UpsertUserAvaterRequest req)
        {
            var command =  new UpsertUserAvatarCommand(req.userId, await req.avatar.GetBytesAsync());
            await _mediator.Send(command);
            return Created();
        }

        [HttpPost]
        [Route("login-cookie-base-auth")]
        public async Task<IActionResult> LoginCookieBase([FromBody]LoginUserCookieBaseCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpPost]
        [Route("assign-role")]
        //[Authorize(Roles = "Admin")]
        public async Task AssignRole([FromBody]AssignRoleCommand command)
        {
            await _mediator.Send(command);
        }

    }
}
