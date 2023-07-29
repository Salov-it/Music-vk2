using MediatR;

namespace MyRecommendationsService.Application.CQRS.Command.DeleteAudio
{
    public class DeleteAudioCommand : IRequest<string>
    {
        public string DeleteAudio { get; set; }
    }
}
