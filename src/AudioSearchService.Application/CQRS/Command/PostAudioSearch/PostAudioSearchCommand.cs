using AudioSearchService.Domain;
using MediatR;

namespace AudioSearchService.Application.CQRS.Command.PostAudioSearch
{
    public class PostAudioSearchCommand : IRequest<string>
    {
        public string AudioSearch { get; set; }
        public int Count { get; set; }
    }
}
