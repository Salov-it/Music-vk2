using MediatR;
using Myaudio.Domain;

namespace Myaudio.Application.CQRS.Command.GetMyaudio
{
    public class GetAudioCommand : IRequest<List<Myaudios>>
    {
        public int CountAudio { get; set; }
    }
}
