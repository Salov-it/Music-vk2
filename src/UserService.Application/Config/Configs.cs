

namespace UserService.Application.Config
{
    public  class Configs
    {
        public ulong ApplicationId = 7822351;
        public string accessToken { get;set; }

        public string AccessToken
        {
            get { return accessToken; }
            set { accessToken = value; }
        }
    }
}
