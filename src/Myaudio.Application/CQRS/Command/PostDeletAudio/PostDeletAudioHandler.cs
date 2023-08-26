using Myaudio.Application.Interface;
using MediatR;

namespace Myaudio.Application.CQRS.Command.PostDeletAudio
{
    public class PostDeletAudioHandler : IRequestHandler<PostDeletAudioCommanda, string>
    {
        private readonly IMyaudiosRepository _myaudiosRepository;
        public string Status { get; set; }

        public PostDeletAudioHandler(IMyaudiosRepository myaudiosRepository)
        {
            _myaudiosRepository = myaudiosRepository;
        }

        public async Task<string> Handle(PostDeletAudioCommanda request, CancellationToken cancellationToken)
        {
            var Files = await _myaudiosRepository.GetAllAsync();
            if (Files != null)
            {

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
                return Status = "Выполнено";
            }
            else
            {
                return Status = "Ошибка: Files = await _audioPopulaRepository.GetAllAsync() ";
            }

            return Status;

        }

    }
}
