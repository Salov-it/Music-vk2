using AudioPopularService.Application.Interface;
using AudioPopularService.Domain;
using MediatR;

namespace AudioPopularService.Application.CQRS.Command.PostDownloadAudio
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
            AudioPopul audio = new AudioPopul
            {
                Urilvk = request.Urilvk,
                Name = request.Name,
            };

            _looadin.LooadingMp3(audio);
            return "Выполнено" ;
        }
    }
}
