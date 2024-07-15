using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using topstory.service.Models;
using topstory.service.Services;

namespace TopStoriesWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StoriesController : ControllerBase
    {
        public readonly IStoryService _storyService;
        public readonly IMemoryCache _cache;
         public const string TopStoriesCacheKey = "TopStories";

        public StoriesController(IStoryService storyService, IMemoryCache cache)
        {
            _storyService = storyService;
            MemoryCacheOptions memoryCacheOptions = new MemoryCacheOptions();
            _cache = cache?? new MemoryCache(memoryCacheOptions);
        }

        /// <summary>
        /// Gets the top 200 stories.
        /// </summary>
        /// <returns>A list of stories</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Story>>> GetTopStories()
        {
            
            if (!_cache.TryGetValue(TopStoriesCacheKey, out IEnumerable<Story> stories))
            {
                 stories = await _storyService.GetTopStoriesAsync();
                _cache.Set(TopStoriesCacheKey, stories, TimeSpan.FromMinutes(5));
            }
            return Ok(stories);
        }
    }
}
