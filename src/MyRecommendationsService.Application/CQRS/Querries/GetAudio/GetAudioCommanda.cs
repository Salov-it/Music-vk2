using MediatR;
using MyRecommendationsService.Application.CQRS.Command.GetAudioDowload;
using MyRecommendationsService.Domain;

namespace MyRecommendationsService.Application.CQRS.Querries.GetAudio
{
    public class GetAudioCommanda : IRequest<List<Audio>>
    {
    }
}
