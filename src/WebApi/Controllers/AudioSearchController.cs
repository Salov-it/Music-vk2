using AudioSearchService.Application.CQRS.Command;
using AudioSearchService.Application.CQRS.Command.GetAudioSearch;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AudioSearchController : ControllerBase
    {
        private readonly IMediator mediator;

        public AudioSearchController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("AudioSearch")]
        public async Task<IActionResult> AudioSearch(string AudioSearch, int CountAudio)
        {
            var content = new GetAudioSearchCommand
            {
                AudioSearch = AudioSearch,
                Count = CountAudio
            };
            var answer = await mediator.Send(content);
            return Ok(answer);
        }

    }
}
