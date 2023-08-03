using MediatR;
using Microsoft.AspNetCore.Mvc;
using UserService.Application.CQRS.Command.PostAuthorization;
using UserService.Application.CQRS.Querries.GetUserInfo;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserServiceController : ControllerBase
    {
        private readonly IMediator mediator;

        public UserServiceController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost("Authorization")]
        public async Task<IActionResult> Authorization(string Login, string Password)
        {
            var content = new PostAuthorizationCommand
            {
                Login = Login,
                Password = Password
            };
            var answer = await mediator.Send(content);
            return Ok(answer);
        }

        [HttpGet("Userinfo")]
        public async Task<IActionResult> Userinfo()
        {
            var content = new GetUserInfoCommand
            {
               
            };
            var answer = await mediator.Send(content);
            return Ok(answer);
        }
    }
}
