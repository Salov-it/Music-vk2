using MediatR;
using UserService.Application.Interface;
using UserService.Application.Config;
using UserService.Application.Api;

namespace UserService.Application.CQRS.Command.PostAuthorization
{
    public class PostAuthorizationHandler : IRequestHandler<PostAuthorizationCommand, string>
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
        
        public async Task<string> Handle(PostAuthorizationCommand request, CancellationToken cancellationToken)
        {
          var UserInfo = await _vkApi.ApiAut(request.Login, request.Password, configs.ApplicationId, cancellationToken);

            var UserContent = new Domain.User
            {
                Login = request.Login,
                Password = request.Password,
                AccessToken = UserInfo.AccessToken,
                Nick = UserInfo.Nick
            };

           await _userRepository.AddAsync(UserContent);
           await _userRepository.SaveChangesAsync();
            
            return UserContent.Nick;
        }
    }
}
