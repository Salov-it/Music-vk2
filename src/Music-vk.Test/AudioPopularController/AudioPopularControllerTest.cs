using System.Net;
using Music_vk.Test.Config;
using Xunit;
using Xunit.Priority;

namespace Music_vk.Test.AudioPopularController
{
    
    [Trait("Category", "Integration")]
    public class AudioPopularControllerTest : IClassFixture<MusicVkWebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public AudioPopularControllerTest(MusicVkWebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact(DisplayName = "Test_2")]
        public async Task GetAudioPopular()
        {
            
            var httpResponse = await _client.GetAsync(requestUri: "api/AudioPopular/AudioPopular?Count=1");

            httpResponse.EnsureSuccessStatusCode();

            Assert.Equal(HttpStatusCode.OK, httpResponse.StatusCode);

        }
    }
}
