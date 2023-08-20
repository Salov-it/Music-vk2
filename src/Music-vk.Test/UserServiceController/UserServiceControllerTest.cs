using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Net;
using System.Net.Http;
using VkNet.Utils;
using Xunit;

namespace Music_vk.Test.UserServiceController
{
    public class UserServiceControllerTest : IClassFixture<MusicVkWebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public UserServiceControllerTest(MusicVkWebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task PostUserAuthorization()
        {
            var login = "89244452428";
            var password = "Salov1999";

            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("Login", login),
                new KeyValuePair<string, string>("Password", password)
            });

            var formData = await content.ReadAsFormDataAsync();



            var httpResponse = await _client.GetAsync(requestUri: "api/UserService/Authorization?Login=89244452428&Password=Salov1999"); 

            httpResponse.EnsureSuccessStatusCode();

            Assert.Equal(HttpStatusCode.OK, httpResponse.StatusCode);
        }
    }
}
