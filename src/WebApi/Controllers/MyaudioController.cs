using MediatR;
using Microsoft.AspNetCore.Mvc;
using Myaudio.Application.CQRS.Command.PostDeletAudio;
using Myaudio.Application.CQRS.Command.PostDownloadAudio;
using Myaudio.Application.CQRS.Query.GetMyaudioDowload;
using Myaudio.Domain;

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

        [HttpPost("DownloadAudio")]
        public async Task<IActionResult> DownloadAudio([FromBody] DownloadAudioModels download)
        {
            var content = new PostDownloadAudioCommand
            {
                downloadAudio = download
            };
            var answer = await mediator.Send(content);
            return Ok(answer);
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
