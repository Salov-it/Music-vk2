using AudioPopularService.Application.CQRS.Command.GetAudioPopular;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AudioPopularController : ControllerBase
    {
        private readonly IMediator mediator;

        public AudioPopularController()
        {
        }

        public AudioPopularController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("AudioPopular")]
        public async Task<IActionResult> AudioPopular(uint Count)
        {
            var content = new GetAudioPopulaCommand
            {
                Count = Count
            };
            var answer = await mediator.Send(content);
            return Ok(answer);
        }
    }
}
