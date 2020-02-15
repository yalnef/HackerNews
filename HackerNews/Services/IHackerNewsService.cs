using HackerNews.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HackerNews.Services
{
    public interface IHackerNewsService
    {
        Task<List<StoryModel>> GetStories(int pageNumber, int pageSize);
        Task<List<StoryModel>> LoadStories();
    }
}
