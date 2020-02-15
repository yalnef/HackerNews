using HackerNews.Models;
using HackerNews.Repositories;
using HackerNews.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HackerNews.Services
{
    public class HackerNewsService : IHackerNewsService
    {
        public HackerNewsService(IHackerNewsRepository hackerNewsRepository)
        {
            HackerNewsRepository = hackerNewsRepository;
        }

        public IHackerNewsRepository HackerNewsRepository { get; }

        public List<StoryModel>GetStories(int pageNumber, int pageSize, string Search)
        {
            int exclude = (pageSize * pageNumber) - pageSize;
            List<StoryModel> storyModels = new List<StoryModel>();
            SingltonHomeStoryViewModel singltonHomeStoryViewModel = SingltonHomeStoryViewModel.Instsance;
            if (singltonHomeStoryViewModel.ListStoryModel != null)
            {
                storyModels = singltonHomeStoryViewModel.ListStoryModel.Where(x => x.Title.Contains(Search.Trim(), StringComparison.OrdinalIgnoreCase) ||
                                                                                   x.By.Contains(Search.Trim(), StringComparison.OrdinalIgnoreCase) ||
                                                                                   Search.Trim() == "").Skip(exclude).Take(pageSize).ToList();
            }

            return storyModels;
        }

        public async Task<List<StoryModel>> LoadStories()
        {
            var ids = await HackerNewsRepository.GetBestStoriesIds();
            List<StoryModel> storyModels = new List<StoryModel>();

            foreach (var id in ids)
            {
                var Story = await HackerNewsRepository.GetStory(id);
                storyModels.Add(Story);
            }

            return storyModels;
        }
    }
}
