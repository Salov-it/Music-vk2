using MediatR;
using UserService.Application.Dto;

namespace UserService.Application.CQRS.Querries.GetUserInfo
{
    public class GetUserInfoCommand : IRequest<UserInfoDto>
    {

    }
}
