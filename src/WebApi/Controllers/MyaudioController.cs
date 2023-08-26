using MediatR;
using Microsoft.AspNetCore.Mvc;
using Myaudio.Application.CQRS.Command.PostDeletAudio;
using Myaudio.Application.CQRS.Query.GetMyaudioDowload;

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

        [HttpPost("DeletAudio")]
        public async Task<IActionResult> DeletAudio()
        {
            var content = new PostDeletAudioCommanda
            {
                
            };
            var answer = await mediator.Send(content);
            return Ok(answer);
        }

        [HttpGet("GetAudo")]
        public async Task<IActionResult> GetAudio([FromQuery] int Count)
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
