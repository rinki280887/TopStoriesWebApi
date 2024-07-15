using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Net.Http;
using topstory.service.Models;
using topstory.service.Services;

namespace topstory.Test
{
    [TestClass]
    public class ServiceTest
    {
        public readonly HttpClient _httpClient;
        public ServiceTest(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        [TestMethod]
        public void GetTopStoriesAsync()
        {            
           var request = new StoryService(_httpClient);
           List<Story> stories = request.GetTopStoriesAsync();
            Assert.AreEqual("Approved",stories !=null && stories.Count > 0 );
        }
    }
}
