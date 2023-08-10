using AudioPopularService.Domain;
using MediatR;

namespace AudioPopularService.Application.CQRS.Command.GetAudioPopular
{
    public class GetAudioPopulaCommand : IRequest<List<AudioPopul>>
    {
        public uint Count { get; set; }
    }
}
