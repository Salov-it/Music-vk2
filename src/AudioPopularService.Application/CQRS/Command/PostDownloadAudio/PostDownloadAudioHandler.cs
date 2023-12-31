﻿using AudioPopularService.Application.Interface;
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
            
            _looadin.LooadingMp3(request.downloadAudio);
            return "Выполнено" ;
        }
    }
}
