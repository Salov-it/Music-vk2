using MediatR;

namespace MyRecommendationsService.Application.CQRS.Command.GetAudioDowload
{
    public class GetAudioDowloadCommand : IRequest<string>
    {
        public uint CountAudio { get; set; }
        public long? UserId { get; set; }
    }
}
