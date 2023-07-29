using MediatR;
using Myaudio.Application.CQRS.Command.GetMyaudio;
using Myaudio.Application.CQRS.Interface;
using Myaudio.Domain;


namespace Myaudio.Application.CQRS.Command.GetMyaudioDowload
{
    public class GetMyaudiosHandler : IRequestHandler<GetAudioDowloadCommand, string>
    {
        private readonly IMyaudiosRepository _repository;
        private readonly IVkApiService _vkApiService;
        private readonly ILooadin _looadin;

        public GetMyaudiosHandler(IMyaudiosRepository repository, IVkApiService vkApiService,ILooadin looadin)
        {
            _repository = repository;
            _vkApiService = vkApiService;
            _looadin = looadin;
        }
        public async Task<string> Handle(GetAudioDowloadCommand request, CancellationToken cancellationToken)
        {
           await ClearDatabaseAsync();

            var audios = await _vkApiService.GetAudiosAsync(request.CountAudio);

            foreach (var audio in audios)
            {
                var myaudio = new Myaudios
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

