using AudioSearchService.Domain;
using MediatR;

namespace AudioSearchService.Application.CQRS.Command.GetAudioSearch
{
    public class GetAudioSearchCommand : IRequest<List<AudioSearc>>
    {
        public string AudioSearch { get; set; }
        public int Count { get; set; }
    }
}
