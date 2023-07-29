using MediatR;
using Microsoft.AspNetCore.Mvc;
using Myaudio.Application.CQRS.Command.DeleteAudio;
using Myaudio.Application.CQRS.Command.GetMyaudio;
using Myaudio.Application.CQRS.Querries.GetAudio;

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

        [HttpGet("GetDowload")]
        public async Task<IActionResult> GetDowload(int CountAudio)
        {
            var content = new GetAudioDowloadCommand
            {
                CountAudio = CountAudio
            };
            var answer = await mediator.Send(content);
            return Ok(answer);
        }



        [HttpGet("GetAudo")]
        public async Task<IActionResult> GetAudio()
        {
            var content = new GetAudioCommanda
            {

            };
            var answer = await mediator.Send(content);
            return Ok(answer);
        }

        [HttpGet("DeleteAudio")]
        public async Task<IActionResult> DeleteAudio(string DeleteAudio)
        {
            var content = new DeleteAudioCommand
            {
                DeleteAudio = DeleteAudio
            };
            var answer = await mediator.Send(content);
            return Ok(answer);
        }
    }
}
