using System.Net;
using Xunit;
using Xunit.Priority;

namespace Music_vk.Test.MyaudioController
{
    [Collection("Test")]
    public class MyaudioControlleTest : IClassFixture<MusicVkWebApplicationFactory<Program>>
    {
       
        private readonly HttpClient _client;

        public MyaudioControlleTest(MusicVkWebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task GetMyAudio()
        {
            await Task.Delay(3000);
            var httpResponse = await _client.GetAsync(requestUri: "api/Myaudio/GetAudo?Count=1");

            httpResponse.EnsureSuccessStatusCode();

            Assert.Equal(HttpStatusCode.OK, httpResponse.StatusCode);
        }
    }
}
