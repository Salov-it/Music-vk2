using AudioSearchService.Application.Dto;
using AudioSearchService.Application.Interface;
using AudioSearchService.Domain;
using MediatR;
using UserService.Application.Interface;

namespace AudioSearchService.Application.CQRS.Command
{
    public class GetAudioSearchHandler : IRequestHandler<GetAudioSearchCommand, List<AudioSearc>>
    {
        private readonly IAudioSearchContext _audioSearchContext;
        private readonly IAudioSearchRepository _audioSearchRepository;
        private readonly IAudioSearch _audioSearch;
        private readonly IAccessToken _accessToken;
        private readonly ILooadin _looadin;
        
        
        public List<AudioSearc> Audios = new List<AudioSearc>();
        public List<AudioSearc> Audios2 { get; set; }

        public GetAudioSearchHandler()
        {
        }

        public GetAudioSearchHandler(IAudioSearchContext audioSearchContext, IAudioSearchRepository audioSearchRepository,
               IAudioSearch audioSearch, IAccessToken accessToken, ILooadin looadin)
        {
            _audioSearchContext = audioSearchContext;
            _audioSearchRepository = audioSearchRepository;
            _audioSearch = audioSearch;
            _accessToken = accessToken;
            _looadin = looadin;
        }

        public async Task<List<AudioSearc>> Handle(GetAudioSearchCommand request, CancellationToken cancellationToken)
        {

            Delete();
                 
                var audios = await _audioSearch.audioSearch(request.AudioSearch, request.Count, _accessToken.AccessToken());
                var Audios1 = new AudioSearc();
              
                foreach (var audio in audios)
                {
                    Audios1 = new AudioSearc
                    {
                        Name = audio.Title,
                        Time = audio.Duration,
                        Urilvk = audio.Url.ToString(),
                        File = $"./mp3/{audio.Title}.mp3"
                    };
                    Audios.Add(Audios1);
                    await _audioSearchRepository.AddAsync(Audios1);
                }

                await _audioSearchRepository.SaveChangesAsync();
               _looadin.LooadingMp3(Audios);
               return Audios2 = Audios;

        }

       public async void Delete()
        {
           
            var Files = await _audioSearchRepository.GetAllAsync();
             
            for (int i = 0; i < Files.Count; i++)
            {
                var FileName1 = Files[i].File;
                if (File.Exists(FileName1))
                {
                    try
                    {
                        File.Delete(FileName1);
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
