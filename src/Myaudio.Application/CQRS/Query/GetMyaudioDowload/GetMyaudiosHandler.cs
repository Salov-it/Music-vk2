using MediatR;
using Myaudio.Application.Interface;
using Myaudio.Domain;


namespace Myaudio.Application.CQRS.Query.GetMyaudioDowload
{
    public class GetMyaudiosHandler : IRequestHandler<GetAudioCommand, List<Myaudios>>
    {
        private readonly IMyaudiosRepository _repository;
        private readonly IVkApiService _vkApiService;
        private readonly ILooadin _looadin;
        private readonly IContext _context;

        List<Myaudios> MyAudio = new List<Myaudios>();



        public GetMyaudiosHandler(IMyaudiosRepository repository, IVkApiService vkApiService, ILooadin looadin, IContext context)
        {
            _repository = repository;
            _vkApiService = vkApiService;
            _looadin = looadin;
            _context = context;
        }
        public async Task<List<Myaudios>> Handle(GetAudioCommand request, CancellationToken cancellationToken)
        {

            Delet();
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
                MyAudio.Add(myaudio);
            }
            await _repository.SaveChangesAsync();

            _looadin.LooadingMp3();

            return MyAudio;
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

        public void Delet()
        {
            var content = _context.Myaudio.ToList();
            for (int i = 0; i < content.Count; i++)
            {
                var FileName = content[i].File;
                if (File.Exists(FileName))
                {
                    try
                    {
                        File.Delete(FileName);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("The deletion failed: {0}", e.Message);
                    }

                }

            }
        }
    }

}

