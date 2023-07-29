using MediatR;
using MyRecommendationsService.Application.Interface;

namespace MyRecommendationsService.Application.CQRS.Command.DeleteAudio
{
    public class DeleteAudioHandler : IRequestHandler<DeleteAudioCommand, string>
    {
      
        public readonly IContextMyRecom _context;
        public DeleteAudioHandler(IContextMyRecom context)
        {
            _context = context;
        }
        public async Task<string> Handle(DeleteAudioCommand request, CancellationToken cancellationToken)
        {
            if (request.DeleteAudio == "Delete")
            {

                var content = _context.Audios.ToList();
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

            return "Выполнено";
        }
    }
    
    
}
