using MediatR;
using UserService.Application.Dto;

namespace UserService.Application.CQRS.Command.PostAuthorization
{
    public class PostAuthorizationCommand : IRequest<UserInfoDto>
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
