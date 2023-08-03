using UserService.Application.Interface;

namespace UserService.Application.Api.AccessToken
{
    public class AccessToken : IAccessToken
    {
        readonly IUserContext _userContext;
        public AccessToken(IUserContext userContext) 
        {
            _userContext = userContext;
        }

        public string accessToken { get; set; }

         string IAccessToken.AccessToken()
         {
             
            var UserContent = _userContext.user.ToList();
            foreach (var usercontent in UserContent)
            {
                accessToken = usercontent.AccessToken;
            }

            return accessToken;
         }
    }
}
