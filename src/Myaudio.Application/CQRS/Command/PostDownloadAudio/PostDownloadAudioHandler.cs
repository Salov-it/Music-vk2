using MediatR;
using Myaudio.Application.Interface;

namespace Myaudio.Application.CQRS.Command.PostDownloadAudio
{
    public class PostDownloadAudioHandler : IRequestHandler<PostDownloadAudioCommand, string>
    {
        private readonly ILooadin _looadin;
        public PostDownloadAudioHandler(ILooadin looadin)
        {
            _looadin = looadin;
        }
        public async Task<string> Handle(PostDownloadAudioCommand request, CancellationToken cancellationToken)
        {
            
            _looadin.LooadingMp3(request.downloadAudio);
            return "Выполнено" ;
        }
    }
}
