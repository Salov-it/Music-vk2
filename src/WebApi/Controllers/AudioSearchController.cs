using AudioSearchService.Application.CQRS.Command.PostAudioSearch;
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

        [HttpPost("AudioSearch")]
        public async Task<IActionResult> AudioSearch([FromBody] JsonContent jsonContent)
        {
             var content = new PostAudioSearchCommand
             {
                AudioSearch = jsonContent.AudioSearch,
                Count = jsonContent.CountAudio
             };
            var answer = await mediator.Send(content);
            return Ok(answer);
        }
        
        public class JsonContent
        {
            public string AudioSearch { get; set; }
            public int CountAudio { get; set; }
        }
    }
}
