using AudioPopularService.Application.CQRS.Command.GetAudioPopular;
using AudioPopularService.Application.CQRS.Command.PostDeletAudio;
using AudioPopularService.Application.CQRS.Command.PostDownloadAudio;
using AudioPopularService.Domain;
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

        public AudioPopularController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost("DownloadAudio")]
        public async Task<IActionResult> DownloadAudio([FromQuery] DownloadAudioModel audioModel)
        {
            var content = new PostDownloadAudioCommand
            {
                downloadAudio = audioModel
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

        [HttpPost("AudioPopular")]
        public async Task<IActionResult> AudioPopular([FromBody] AudioPopulModel audioPopulModel)
        {
            var content = new GetAudioPopulaCommand
            {
                audioPopulModel = audioPopulModel
            };
            var answer = await mediator.Send(content);
            return Ok(answer);
        }

    }

    
}
