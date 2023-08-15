using FakeItEasy;
using System.ComponentModel.DataAnnotations;
using System.Net;
using WebApi.Controllers;
using Xunit;

namespace Music_vk.Test.AudioPopularService.Test.AudioPopularControllerTest
{
    public class AudioPopularControllerTest 
    {
        public readonly AudioPopularController _audioPopularController;
        public AudioPopularControllerTest(AudioPopularController audioPopularController)
        {
            _audioPopularController = audioPopularController;
        }


        [Fact]
        public async Task Get_ReturnsOk()
        {
            // Arrange
           

            // Act

           
            var response = await client.GetAsync("api/AudioPopularController/AudioPopular/1");

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
