using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyRecommendationsService.Application.CQRS.Command.DeleteAudio;
using MyRecommendationsService.Application.CQRS.Command.GetAudioDowload;
using MyRecommendationsService.Application.CQRS.Querries.GetAudio;

namespace MyRecommendationsService.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MyaudioController : ControllerBase
    {
        private readonly IMediator mediator;

        public MyaudioController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("GetDowload")]
        public async Task<IActionResult> GetDowload(uint CountAudio, uint? UserId)
        {
            var content = new GetAudioDowloadCommand
            {
                CountAudio = CountAudio,
                UserId = UserId
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
