using Microsoft.EntityFrameworkCore;
using UserService.Application.Interface;
using UserService.Domain;

namespace UserService.Application.CQRS.Command.PostAuthorization
{
    public class UserRepository : IUserRepository
    {
        private readonly IUserContext _userContext;
        CancellationToken cancellationToken = new CancellationToken();

        public UserRepository(IUserContext userContext)
        {
            _userContext = userContext;
        }
        public async Task AddAsync(User user)
        {
            await _userContext.user.AddAsync(user);
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _userContext.user.ToListAsync();
        }

        public void Remove(User users)
        {
            _userContext.user.Remove(users);
        }

        public async Task SaveChangesAsync()
        {
            await _userContext.SaveChangesAsync(cancellationToken);
        }

    }
}

