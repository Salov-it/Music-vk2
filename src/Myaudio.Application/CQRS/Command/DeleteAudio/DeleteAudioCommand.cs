using MediatR;

namespace Myaudio.Application.CQRS.Command.DeleteAudio
{
    public class DeleteAudioCommand : IRequest<string>
    {
        public string DeleteAudio { get; set; }
    }
}
