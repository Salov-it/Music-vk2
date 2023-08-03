using MediatR;
using UserService.Domain;
using VkNet.Model;

namespace UserService.Application.CQRS.Command.PostAuthorization
{
    public class PostAuthorizationCommand : IRequest<string>
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
