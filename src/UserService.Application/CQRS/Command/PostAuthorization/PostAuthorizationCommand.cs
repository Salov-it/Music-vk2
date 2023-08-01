using MediatR;

namespace UserService.Application.CQRS.Command.PostAuthorization
{
    public class PostAuthorizationCommand : IRequest<string>
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
