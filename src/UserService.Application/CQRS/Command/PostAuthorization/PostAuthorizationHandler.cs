using MediatR;
using UserService.Application.Interface;
using UserService.Application.Config;
using UserService.Application.Api;
using UserService.Application.Dto;

namespace UserService.Application.CQRS.Command.PostAuthorization
{
    public class PostAuthorizationHandler : IRequestHandler<PostAuthorizationCommand, UserInfoDto>
    {
        readonly IVkaApi _vkApi;
        readonly IUserRepository _userRepository;
      public  PostAuthorizationHandler(IVkaApi vkaApi, IUserRepository userRepository)
      {
          _vkApi = vkaApi;
          _userRepository = userRepository;
      } 
        VKApi vKApi = new VKApi();
        Configs configs = new Configs();
        
        public async Task<UserInfoDto> Handle(PostAuthorizationCommand request, CancellationToken cancellationToken)
        {
            await ClearDatabaseAsync();
            var UserInfo = await _vkApi.ApiAut(request.Login, request.Password, configs.ApplicationId, cancellationToken);

            var UserContent = new Domain.User
            {
                Login = request.Login,
                Password = request.Password,
                AccessToken = UserInfo.AccessToken,
                Nick = UserInfo.Nick,
                Avatar = UserInfo.Avatar
            };

            var userInfoDto = new UserInfoDto
            {
                Name = UserContent.Nick,
                Avatar = UserContent.Avatar,
            };

            await _userRepository.AddAsync(UserContent);
            await _userRepository.SaveChangesAsync();
            return userInfoDto;
        }
        private async Task ClearDatabaseAsync()
        {
            var myaudios = await _userRepository.GetAllAsync();

            foreach (var myaudio in myaudios)
            {
                _userRepository.Remove(myaudio);
            }
            await _userRepository.SaveChangesAsync();
        }
    }
}
