using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http;
using UserService.Application.CQRS.Command.PostAuthorization;
using UserService.Application.CQRS.Querries.GetUserInfo;
using FromBodyAttribute = Microsoft.AspNetCore.Mvc.FromBodyAttribute;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

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

        [HttpGet("Authorization")]
        public async Task<IActionResult> Authorization([FromQuery]string Login,string Password)
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
