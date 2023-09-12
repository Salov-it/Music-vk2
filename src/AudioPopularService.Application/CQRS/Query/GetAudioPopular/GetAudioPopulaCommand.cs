using AudioPopularService.Domain;
using MediatR;

namespace AudioPopularService.Application.CQRS.Command.GetAudioPopular
{
    public class GetAudioPopulaCommand : IRequest<string>
    {
       public AudioPopulModel audioPopulModel { get; set; }
    }
}
