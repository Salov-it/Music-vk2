using MediatR;
using Myaudio.Domain;

namespace Myaudio.Application.CQRS.Querries.GetAudio
{
    public class GetAudioCommanda : IRequest<List<Myaudios>>
    {
    }
}
