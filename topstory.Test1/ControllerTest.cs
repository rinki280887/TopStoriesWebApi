using Microsoft.Extensions.Caching.Memory;
using System.Net.Http;
using System.Threading.Tasks;
using TopStoriesWebApi.Controllers;
using topstory.service.Services;
using Xunit;

namespace topstory.Test1
{
    public class ControllerTest
    {
        public readonly IStoryService _storyService;
        
        public readonly HttpClient _httpClient;
        public ControllerTest()
        {
            _httpClient = new HttpClient();
            _storyService = new StoryService(_httpClient);            
        }
        [Fact]
        public async Task GetTopStories()
        {
            var request = new StoriesController(_storyService,null);
            var result = await request.GetTopStories();
            Assert.NotNull(result);
        }
    }
}
