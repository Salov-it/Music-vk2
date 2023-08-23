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
        public async Task<IActionResult> AudioSearch([FromBody] JsonAudioSearch jsonAudio)
        {
            var content = new GetAudioSearchCommand
            {
                AudioSearch = jsonAudio.AudioSearch,
                Count = jsonAudio.CountAudio
            };
            var answer = await mediator.Send(content);
            return Ok(answer);
        }

        public class JsonAudioSearch
        {
            public string AudioSearch { get; set; }
            public int CountAudio { get; set; }
        }

    }
}
