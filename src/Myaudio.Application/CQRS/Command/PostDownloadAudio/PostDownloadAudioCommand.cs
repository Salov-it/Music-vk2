using MediatR;
using Myaudio.Domain;

namespace Myaudio.Application.CQRS.Command.PostDownloadAudio
{
    public class PostDownloadAudioCommand : IRequest<string>
    {
        public DownloadAudioModels downloadAudio { get; set; }

    }
}
