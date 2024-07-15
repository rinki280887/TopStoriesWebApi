using System.Collections.Generic;
using System.Threading.Tasks;
using topstory.service.Models;

namespace topstory.service.Services
{
    public interface IStoryService
    {
        Task<IEnumerable<Story>> GetTopStoriesAsync();
    }
}