using Music_vk_Client_Api.Config;
using System.Formats.Asn1;
using System.Net;
using System.Net.Http;


namespace Music_vk_Client_Api.Api.GetAudioPopular
{
    public class GetAudioPopularCommand
    {
        static HttpClient _Client = new HttpClient();

        public GetAudioPopularCommand()
        {
        }

        public GetAudioPopularCommand(HttpClient client)
        {
            _Client = client;
        }

        public async Task<string> GetAudioPopular(uint Count)
        {
            Configs configs = new Configs();
            
            using HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, configs.AudioPopularServerUril+"Count="+ Count);

            using HttpResponseMessage response = await _Client.SendAsync(request);
            return await response.Content.ReadAsStringAsync();
        }
    }
}
