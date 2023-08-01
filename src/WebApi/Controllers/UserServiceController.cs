using MediatR;
using Microsoft.AspNetCore.Mvc;
using UserService.Application.CQRS.Command.PostAuthorization;

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

        [HttpPost("PostAuthorization")]
        public async Task<IActionResult> PostAuthorization(string Login, string Password)
        {
            var content = new PostAuthorizationCommand
            {
                Login = Login,
                Password = Password
            };
            var answer = await mediator.Send(content);
            return Ok(answer);
        }
    }
}
