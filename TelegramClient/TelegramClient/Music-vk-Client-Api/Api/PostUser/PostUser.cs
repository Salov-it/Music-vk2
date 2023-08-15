using Music_vk_Client_Api.Config;

namespace Music_vk_Client_Api.Api.GetUser
{
    public class PostUser
    {
        static HttpClient _Client = new HttpClient();

        public async Task<string> User(string Login, string Password)
        {
            Configs configs = new Configs();

            using HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, configs.UserServerUril +"Login=" +Login+ "&"+"Password="+Password);

            using HttpResponseMessage response = await _Client.SendAsync(request);

            return await response.Content.ReadAsStringAsync();
        }
    }
}
