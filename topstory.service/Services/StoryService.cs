using topstory.service.Models;
using System.Text.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using System;
using System.Linq;

namespace topstory.service.Services
{
    public class StoryService : IStoryService
    {
        public readonly HttpClient _httpClient;       

        public StoryService(HttpClient httpClient)
        {
            _httpClient = httpClient;            
        }

        public async Task<IEnumerable<Story>> GetTopStoriesAsync()
        {            
                var response = await _httpClient.GetStringAsync("https://hacker-news.firebaseio.com/v0/topstories.json");
                var topStoryIds = JsonSerializer.Deserialize<List<int>>(response).Take(200);
                List<Story> stories = new List<Story>();     
                 
                   foreach(int id in topStoryIds)
                     {
                         var storyResponse = await _httpClient.GetStringAsync($"https://hacker-news.firebaseio.com/v0/item/{id}.json");
                         var story = JsonSerializer.Deserialize<Story>(storyResponse);

                         if (story != null)
                         {
                             stories.Add(story);
                         }
                     }                
                                 

            return stories;
        }

    }
}
