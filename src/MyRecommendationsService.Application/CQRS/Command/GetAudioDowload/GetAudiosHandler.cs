using MediatR;
using MyRecommendationsService.Application.Interface;
using MyRecommendationsService.Domain;

namespace MyRecommendationsService.Application.CQRS.Command.GetAudioDowload
{
    public class GetAudiosHandler : IRequestHandler<GetAudioDowloadCommand, string>
    {
        private readonly IAudiosRepository _repository;
        private readonly IVkApiServiceMyRecom _vkApiService;
        private readonly ILooadinMyRecom _looadin;

        public GetAudiosHandler(IAudiosRepository repository, IVkApiServiceMyRecom vkApiService, ILooadinMyRecom looadin)
        {
            _repository = repository;
            _vkApiService = vkApiService;
            _looadin = looadin;
        }
        public async Task<string> Handle(GetAudioDowloadCommand request, CancellationToken cancellationToken)
        {
            await ClearDatabaseAsync();

            var audios = await _vkApiService.GetAudiosAsync(request.CountAudio,request.UserId);

            foreach (var audio in audios)
            {
                var audios2 = new Audio
                {
                    Name = audio.Title,
                    Time = audio.Duration,
                    Urilvk = audio.Url.ToString(),
                    File = $"./mp3/{audio.Title}.mp3"
                };

                await _repository.AddAsync(audios2);
            }
            await _repository.SaveChangesAsync();

            _looadin.LooadingMp3();

            return "ok";
        }

        private async Task ClearDatabaseAsync()
        {
            var audios = await _repository.GetAllAsync();

            foreach (var audio in audios)
            {
                _repository.Remove(audio);
            }

            await _repository.SaveChangesAsync();
        }
    }
}
