using UserService.Domain;

namespace UserService.Application.Interface
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllAsync();
        Task AddAsync(User user);
        void Remove(User user);
        Task SaveChangesAsync();
    }
}
