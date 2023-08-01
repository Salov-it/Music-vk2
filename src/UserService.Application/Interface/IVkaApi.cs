

namespace UserService.Application.Interface
{
    public interface IVkaApi
    {
        public void ApiAut(string Login, string Password, ulong ApplicationId);
    }
}
