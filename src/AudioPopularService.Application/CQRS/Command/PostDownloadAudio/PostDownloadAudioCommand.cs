using MediatR;
using System.Text.Json.Nodes;

namespace AudioPopularService.Application.CQRS.Command.PostDownloadAudio
{
    public class PostDownloadAudioCommand : IRequest<string>
    {
        public string Urilvk { get; set; }
        public string Name { get; set; }    
    }
}
