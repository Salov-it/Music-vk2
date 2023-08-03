using Microsoft.Extensions.DependencyInjection;
using UserService.Application.Interface;
using VkNet;
using VkNet.AudioBypassService.Extensions;
using VkNet.Model;
using UserService.Application.Config;
using VkNet.Enums.Filters;
using UserService.Domain;
using System.Text.Json;

namespace UserService.Application.Api
{
    public class VKApi : IVkaApi
    {
      
        readonly IUserContext _userContext;

        public VKApi(IUserContext userContext)
        {
            _userContext = userContext;
        }

        public VKApi()
        {
        }

        public async Task<Domain.User> ApiAut(string Login, string Password, ulong ApplicationId, CancellationToken cancellationToken) 
        {
            var services = new ServiceCollection();
            services.AddAudioBypass();
            var Api = new VkApi(services);
            Configs configs = new Configs();
            


            Api.Authorize(new ApiAuthParams
            {
                  ApplicationId = ApplicationId,
                  Login = Login,
                  Password = Password,
            });
            
            //Получаем Имя И фамилию текущего профиля
            var UserInfo =  Api.Users.Get(new long[] {Api.UserId.Value}, 
                ProfileFields.FirstName | ProfileFields.LastName).FirstOrDefault();

            string Userinfo = UserInfo.FirstName + " " + UserInfo.LastName;
            var UserContent = new Domain.User
            {
               Nick = Userinfo,
               AccessToken = Api.Token
            };
            
            return UserContent;
        }
    }
}
