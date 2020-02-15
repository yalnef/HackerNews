using HackerNews.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HackerNews.Repositories
{
    public interface IHackerNewsRepository
    {
        Task<StoryModel> GetStory(int id);
        Task<int[]> GetBestStoriesIds();
    }
}
