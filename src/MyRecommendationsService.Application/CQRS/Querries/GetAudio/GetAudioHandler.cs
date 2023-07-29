using MediatR;
using MyRecommendationsService.Application.Interface;
using MyRecommendationsService.Domain;

namespace MyRecommendationsService.Application.CQRS.Querries.GetAudio
{
    public class GetAudioHandler : IRequestHandler<GetAudioCommanda, List<Audio>>
    {
        public readonly IContextMyRecom _context;
        public GetAudioHandler(IContextMyRecom context)
        {
            _context = context;
        }
        public List<Audio> Content { get; set; }

        public async Task<List<Audio>> Handle(GetAudioCommanda request, CancellationToken cancellationToken)
        {

            var Content = _context.Audios.ToList();

            return Content;
        }
    }
}
