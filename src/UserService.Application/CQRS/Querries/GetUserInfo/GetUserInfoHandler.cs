using MediatR;
using UserService.Application.Dto;
using UserService.Application.Interface;

namespace UserService.Application.CQRS.Querries.GetUserInfo
{
    public class GetUserInfoHandler : IRequestHandler<GetUserInfoCommand, UserInfoDto>
    {
        readonly IUserContext _userContext;
        public GetUserInfoHandler(IUserContext userContext)
        {
            _userContext = userContext;
        }

        public async Task<UserInfoDto> Handle(GetUserInfoCommand request, CancellationToken cancellationToken)
        {
            var UserinfoContent = _userContext.user.ToList();

            var userInfo = new UserInfoDto
            {
                Name = UserinfoContent[0].Nick,
                Avatar = UserinfoContent[0].Avatar
            };
            return userInfo;
        }
    }
}
