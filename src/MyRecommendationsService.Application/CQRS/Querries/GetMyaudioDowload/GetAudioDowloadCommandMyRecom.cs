using MediatR;

namespace Myaudio.Application.CQRS.Command.GetMyaudio
{
    public class GetAudioDowloadCommandMyRecom : IRequest<string>
    {
        public int CountAudio { get; set; }
        public uint UserId { get;set; }
    }
}
