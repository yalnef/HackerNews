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

        public async Task<List<StoryModel>>GetStories(int pageNumber, int pageSize)
        {
            var ids = await HackerNewsRepository.GetBestStoriesIds();
            int exclude = (pageSize * pageNumber) - pageSize;
            List<StoryModel> storyModels = new List<StoryModel>();

            var pages = ids.Skip(exclude).Take(pageSize);
            foreach (var id in pages)
            {
                var Story = await HackerNewsRepository.GetStory(id);
                storyModels.Add(Story);
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
            SingltonHomeStoryViewModel singltonHomeStoryViewModel = SingltonHomeStoryViewModel.Instsance;
            singltonHomeStoryViewModel.ListStoryModel = storyModels;
            return storyModels;
        }
    }
}
