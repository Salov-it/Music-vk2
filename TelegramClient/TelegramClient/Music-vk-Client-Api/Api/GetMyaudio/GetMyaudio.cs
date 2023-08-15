

using Music_vk_Client_Api.Config;

namespace Music_vk_Client_Api.Api.GetMyaudio
{
    public class GetMyaudio
    {
        static HttpClient _Client = new HttpClient();

        public GetMyaudio()
        {
        }

        public GetMyaudio(HttpClient Client)
        {
            _Client = Client;
        }

        public async Task<string> MyAudio(int Count)
        {
            Configs configs = new Configs();

            using HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, configs.MyAudioServerUril + "Count=" + Count);

            using HttpResponseMessage response = await _Client.SendAsync(request);
            return await response.Content.ReadAsStringAsync();
        }
    }
}
