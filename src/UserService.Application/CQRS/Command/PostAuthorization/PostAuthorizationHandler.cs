using MediatR;
using UserService.Application.Interface;
using UserService.Application.Config;

namespace UserService.Application.CQRS.Command.PostAuthorization
{
    public class PostAuthorizationHandler : IRequestHandler<PostAuthorizationCommand, string>
    {
        readonly IVkaApi _vkApi;
      public  PostAuthorizationHandler(IVkaApi vkaApi)
        {
            _vkApi = vkaApi;
        }

        Configs configs = new Configs();
        
        public async  Task<string> Handle(PostAuthorizationCommand request, CancellationToken cancellationToken)
        {
            _vkApi.ApiAut(request.Login, request.Password, configs.ApplicationId);

            return  "Авторизован";
        }
    }
}
