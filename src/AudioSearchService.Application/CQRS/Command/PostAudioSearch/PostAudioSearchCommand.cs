using AudioSearchService.Domain;
using MediatR;

namespace AudioSearchService.Application.CQRS.Command.PostAudioSearch
{
    public class PostAudioSearchCommand : IRequest<List<AudioSearc>>
    {
        public string AudioSearch { get; set; }
        public int Count { get; set; }
    }
}
