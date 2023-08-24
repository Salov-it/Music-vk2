using Myaudio.Domain;

namespace Myaudio.Application.Interface
{
    public interface IMyaudiosRepository
    {
        Task<List<Myaudios>> GetAllAsync();
        Task AddAsync(Myaudios myaudio);
        void Remove(Myaudios myaudio);
        Task SaveChangesAsync();
    }
}
