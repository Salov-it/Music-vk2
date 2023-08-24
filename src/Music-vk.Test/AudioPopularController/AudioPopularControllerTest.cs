using System.Net;
using Xunit;
using Xunit.Priority;

namespace Music_vk.Test.AudioPopularController
{
    [Collection("Test")]
    public class AudioPopularControllerTest : IClassFixture<MusicVkWebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public AudioPopularControllerTest(MusicVkWebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task GetAudioPopular()
        {
            
            var httpResponse = await _client.GetAsync(requestUri: "api/AudioPopular/AudioPopular?Count=1");

            httpResponse.EnsureSuccessStatusCode();

            Assert.Equal(HttpStatusCode.OK, httpResponse.StatusCode);

        }
    }
}
