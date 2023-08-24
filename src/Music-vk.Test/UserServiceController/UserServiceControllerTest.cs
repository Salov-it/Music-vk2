using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Net;
using System.Net.Http;
using VkNet.Utils;
using Xunit;
using System.Text.Json;
using Newtonsoft.Json;
using System;
using System.Net.Http.Json;
using Xunit.Priority;

namespace Music_vk.Test.UserServiceController
{
    [Collection("Test")]
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
            
            JsonUser jsonUser = new JsonUser
            {
                Login = "89244452428",
                Password = "Salov1999"
            };
            
            var httpResponse = await _client.PostAsJsonAsync(requestUri:"api/UserService/Authorization",jsonUser); 

            httpResponse.EnsureSuccessStatusCode();

            Assert.Equal(HttpStatusCode.OK, httpResponse.StatusCode);
        }

        public class JsonUser
        {
            public string Login { get; set; }
            public string Password { get; set; }
        }
    }
}
