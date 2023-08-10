﻿using AudioPopularService.Application.Interface;
using AudioPopularService.Domain;
using MediatR;
using UserService.Application.Interface;

namespace AudioPopularService.Application.CQRS.Command.GetAudioPopular
{
    public class GetAudioPopulaHandler : IRequestHandler<GetAudioPopulaCommand, List<AudioPopul>>
    {
        private readonly IAudioPopular _audioPopular;
        private readonly IAccessToken _accessToken;
        private readonly IAudioPopulaRepository _audioPopulaRepository;
        private readonly ILooadin _looadin;

        public List<AudioPopul> Audios = new List<AudioPopul>();

        public GetAudioPopulaHandler()
        {
        }

        public GetAudioPopulaHandler(IAudioPopular audioPopular, IAccessToken accessToken,
            IAudioPopulaRepository audioPopulaRepository, ILooadin looadin)
        { 
            _audioPopular = audioPopular;
            _accessToken = accessToken;
            _audioPopular = audioPopular;
            _looadin = looadin;
        }  
        public async Task<List<AudioPopul>> Handle(GetAudioPopulaCommand request, CancellationToken cancellationToken)
        {
            var audios = await _audioPopular.AudioPopular(request.Count, _accessToken.AccessToken());
            var Audios2 = new AudioPopul();

            foreach (var audio in audios)
            {

                Audios2 = new AudioPopul
                {
                    Name = audio.Title,
                    Time = audio.Duration,
                    Urilvk = audio.Url.ToString(),
                    File = $"./mp3/{audio.Title}.mp3"
                };

                Audios.Add(Audios2);
                await _audioPopulaRepository.AddAsync(Audios2);
            }

            await _audioPopulaRepository.SaveChangesAsync();
            _looadin.LooadingMp3(Audios);
            return Audios;

        }
    }
}
