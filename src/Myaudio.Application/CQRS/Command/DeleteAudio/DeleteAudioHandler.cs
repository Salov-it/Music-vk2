using MediatR;
using Myaudio.Application.CQRS.Interface;
using File = System.IO.File;

namespace Myaudio.Application.CQRS.Command.DeleteAudio
{
    internal class DeleteAudioHandler : IRequestHandler<DeleteAudioCommand, string>
    {
        public readonly IContext _context;
        public DeleteAudioHandler(IContext context)
        {
            _context = context;
        }
        public async Task<string> Handle(DeleteAudioCommand request, CancellationToken cancellationToken)
        {
            if (request.DeleteAudio == "Delete")
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

            return "Выполнено";
        }
    }
}
