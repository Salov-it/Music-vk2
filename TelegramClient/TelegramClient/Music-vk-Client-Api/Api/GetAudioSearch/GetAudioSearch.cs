using Music_vk_Client_Api.Config;

namespace Music_vk_Client_Api.Api.GetAudioSearch
{
    public class GetAudioSearch
    {
        static HttpClient _Client = new HttpClient();

        public GetAudioSearch()
        {
        }

        public GetAudioSearch(HttpClient client)
        {
            _Client = client;
        }

        public async Task<string> GetAudioSearc(string AudioSearch, int Count)
        {
            Configs configs = new Configs();

            using HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, configs.AudioSearchServerUril + "AudioSearch=" + AudioSearch + "&" + "CountAudio=" + Count);

            using HttpResponseMessage response = await _Client.SendAsync(request);
            return await response.Content.ReadAsStringAsync();
        }
    }
}
