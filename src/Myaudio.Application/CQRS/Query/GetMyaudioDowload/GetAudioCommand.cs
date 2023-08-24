using MediatR;
using Myaudio.Domain;

namespace Myaudio.Application.CQRS.Query.GetMyaudioDowload
{
    public class GetAudioCommand : IRequest<List<Myaudios>>
    {
        public int CountAudio { get; set; }
    }
}
