using UserService.Domain;

namespace UserService.Application.Interface
{
    public interface IVkaApi
    {
        public Task<User> ApiAut(string Login, string Password, ulong ApplicationId, CancellationToken cancellationToken);
    }
}
