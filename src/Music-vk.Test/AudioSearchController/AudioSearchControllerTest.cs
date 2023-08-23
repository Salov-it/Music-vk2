using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Priority;

namespace Music_vk.Test.AudioSearchController
{
    [Collection("Test")]
    public class AudioSearchControllerTest : IClassFixture<MusicVkWebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public AudioSearchControllerTest(MusicVkWebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task GetAudioSearch()
        {
            await Task.Delay(3000);
            JsonContent content = new JsonContent
            {
                AudioSearch = "Гуф",
                CountAudio = 1
            };
          
            var httpResponse = await _client.PostAsJsonAsync(requestUri: "api/AudioSearch/AudioSearch",content);

            httpResponse.EnsureSuccessStatusCode();

            Assert.Equal(HttpStatusCode.OK, httpResponse.StatusCode);
        }

       public class JsonContent
       {
            public string AudioSearch { get; set; }
            public int CountAudio { get; set; }
       }

    }
}
