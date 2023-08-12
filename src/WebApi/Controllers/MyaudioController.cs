using MediatR;
using Microsoft.AspNetCore.Mvc;
using Myaudio.Application.CQRS.Command.GetMyaudio;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Myaudio.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyaudioController : ControllerBase
    {
        private readonly IMediator mediator;

        public MyaudioController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("GetAudo")]
        public async Task<IActionResult> GetAudio(int Count)
        {
            var content = new GetAudioCommand
            {
                CountAudio = Count
            };
            var answer = await mediator.Send(content);
            return Ok(answer);
        }

    }
}
