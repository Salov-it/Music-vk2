using AudioPopularService.Application.Interface;
using AudioPopularService.Domain;
using MediatR;

namespace AudioPopularService.Application.CQRS.Command.GetAudioPopular
{
    public class GetAudioPopulaHandler : IRequestHandler<GetAudioPopulaCommand, List<AudioPopul>>
    {
        private readonly IAudioPopularContext _audioPopularContext;
        private readonly IAudioPopular _audioPopular;
        public GetAudioPopulaHandler(IAudioPopularContext audioPopularContext, IAudioPopular audioPopular)
        { 
            _audioPopularContext = audioPopularContext;
            _audioPopular = audioPopular;
        }  
        public Task<List<AudioPopul>> Handle(GetAudioPopulaCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
