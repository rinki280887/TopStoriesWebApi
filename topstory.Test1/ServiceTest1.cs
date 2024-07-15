using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using topstory.service.Models;
using topstory.service.Services;
using Xunit;

namespace topstory.Test1
{
    public class ServiceTest1
    {
        public readonly HttpClient _httpClient;
        public ServiceTest1()
        {
            _httpClient = new HttpClient();
        }
        [Fact]
        public async Task  GetTopStoriesAsync()
        {
            var request = new StoryService(_httpClient);
           // var stories = request.GetTopStoriesAsync();
            var result = await request.GetTopStoriesAsync();
            Assert.NotNull(result);
        }
    }
}
