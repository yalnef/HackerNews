using HackerNews.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HackerNews.Services
{
    public interface IHackerNewsService
    {
        List<StoryModel> GetStories(int pageNumber, int pageSize, string Search);
        Task<List<StoryModel>> LoadStories();
    }
}
