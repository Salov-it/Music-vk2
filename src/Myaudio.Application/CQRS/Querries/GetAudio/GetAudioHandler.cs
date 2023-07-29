using MediatR;
using Myaudio.Application.CQRS.Interface;
using Myaudio.Domain;
namespace Myaudio.Application.CQRS.Querries.GetAudio
{
    public class GetAudioHandler : IRequestHandler<GetAudioCommanda, List<Myaudios>>
    {
        public readonly IContext _context;
        public GetAudioHandler(IContext context)
        {
            _context = context;
        }
        public List<Myaudios> Content { get; set; }

        public async Task <List<Myaudios>> Handle(GetAudioCommanda request, CancellationToken cancellationToken)
        {
            
           var Content = _context.Myaudio.ToList();

           return Content;
        }
    }
}
