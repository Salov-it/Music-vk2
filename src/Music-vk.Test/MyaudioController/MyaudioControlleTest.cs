using System.Net;
using Music_vk.Test.Config;
using Xunit;
using Xunit.Priority;

namespace Music_vk.Test.MyaudioController
{
    
    [Trait("Category", "Integration")]
    public class MyaudioControlleTest : IClassFixture<MusicVkWebApplicationFactory<Program>>
    {
       
        private readonly HttpClient _client;

        public MyaudioControlleTest(MusicVkWebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact(DisplayName = "Test_4")]
        public async Task GetMyAudio()
        {
           
            var httpResponse = await _client.GetAsync(requestUri: "api/Myaudio/GetAudo?Count=1");

            httpResponse.EnsureSuccessStatusCode();

            Assert.Equal(HttpStatusCode.OK, httpResponse.StatusCode);
        }
    }
}
