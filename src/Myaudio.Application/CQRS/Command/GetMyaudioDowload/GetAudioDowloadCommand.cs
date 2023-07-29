using MediatR;

namespace Myaudio.Application.CQRS.Command.GetMyaudio
{
    public class GetAudioDowloadCommand : IRequest<string>
    {
        public int CountAudio { get; set; }
    }
}
