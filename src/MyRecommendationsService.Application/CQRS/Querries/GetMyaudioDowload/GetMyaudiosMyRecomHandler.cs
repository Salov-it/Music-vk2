using MediatR;
using Myaudio.Application.CQRS.Command.GetMyaudio;
using MyRecommendationsService.Application.Interface;
using MyRecommendationsService.Domain;

namespace Myaudio.Application.CQRS.Command.GetMyaudioDowload
{
    public class GetMyaudiosMyRecomHandler : IRequestHandler<GetAudioDowloadCommandMyRecom, string>
    {
        private readonly IAudiosRepository _repository;
        private readonly IVkApiServiceMyRecom _vkApiService;
        private readonly ILooadinMyRecom _looadin;

        public GetMyaudiosMyRecomHandler(IAudiosRepository repository, IVkApiServiceMyRecom vkApiService, ILooadinMyRecom looadin)
        {
            _repository = repository;
            _vkApiService = vkApiService;
            _looadin = looadin;
        }
        public async Task<string> Handle(GetAudioDowloadCommandMyRecom request, CancellationToken cancellationToken)
        {
           await ClearDatabaseAsync();

            var audios = await _vkApiService.GetAudiosAsync((uint)request.CountAudio, request.UserId);

            foreach (var audio in audios)
            {
                var myaudio = new Audio
                {
                    Name = audio.Title,
                    Time = audio.Duration,
                    Urilvk = audio.Url.ToString(),
                    File = $"./mp3/{audio.Title}.mp3"
                };

                await _repository.AddAsync(myaudio);
            }
            await _repository.SaveChangesAsync();

            _looadin.LooadingMp3();

            return "ok";
        }

        private async Task ClearDatabaseAsync()
        {
            var myaudios = await _repository.GetAllAsync();

            foreach (var myaudio in myaudios)
            {
                _repository.Remove(myaudio);
            }

            await _repository.SaveChangesAsync();
        }
    }

}

