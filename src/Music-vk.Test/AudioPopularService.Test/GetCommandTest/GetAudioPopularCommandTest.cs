using AudioPopularService.Application.CQRS.Command.GetAudioPopular;
using System.Net.Http;
using Xunit;

namespace Music_vk.Test.AudioPopularService.Test.GetCommandTest
{
    public class GetAudioPopularCommandTest
    {
        private HttpClient _client;

        public GetAudioPopularCommandTest(HttpClient client)
        {
            _client = client;
        }
        [Fact]
        public async Task GetAudioPopularCommand()
        {
            var handler = await handler.Handle(
              new GetAudioPopulaCommand()
              {
                  Count = 1,
              }
              );
        }
    }
}
