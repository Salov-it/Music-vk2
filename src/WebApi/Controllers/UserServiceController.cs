using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http;
using UserService.Application.CQRS.Command.PostAuthorization;
using UserService.Application.CQRS.Command.PostDeletUser;
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

        [HttpPost("Authorization")]
        public async Task<IActionResult> Authorization([FromBody] JsonUser jsonUser)
        {
            var content = new PostAuthorizationCommand
            {
                Login = jsonUser.Login,
                Password = jsonUser.Password
            };
            var answer = await mediator.Send(content);
            return Ok(answer);
        }

        [HttpPost("DeletUser")]
        public async Task<IActionResult> DeletUser()
        {
            var content = new PostDeletUserCommanda
            {
               
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
        
        public class JsonUser
        {
            public string Login { get; set; }
            public string Password { get; set; }
        }
    }
}
