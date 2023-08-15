using static System.Net.WebRequestMethods;

namespace Music_vk_Client_Api.Config
{
    public class Configs
    {
        public string AudioPopularServerUril = "https://localhost:7239/api/AudioPopular/AudioPopular?";

        public string UserServerUril = "https://localhost:7239/api/UserService/Authorization?";

        public string AudioSearchServerUril = "https://localhost:7239/api/AudioSearch/AudioSearch?";

        public string MyAudioServerUril = "https://localhost:7239/api/Myaudio/GetAudo?";
    }
}
