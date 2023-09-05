using AudioPopularService.Domain;
using MediatR;

namespace AudioPopularService.Application.CQRS.Command.PostDownloadAudio
{
    public class PostDownloadAudioCommand : IRequest<string>
    {
        public DownloadAudioModel downloadAudio { get;set; }
    }
}
