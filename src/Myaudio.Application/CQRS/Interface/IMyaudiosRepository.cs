using Myaudio.Domain;

namespace Myaudio.Application.CQRS.Interface
{
    public interface IMyaudiosRepository
    {
        Task<List<Myaudios>> GetAllAsync();
        Task AddAsync(Myaudios myaudio);
        void Remove(Myaudios myaudio);
        Task SaveChangesAsync();
    }
}
