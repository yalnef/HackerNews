using System;
using System.Net.Http;
using System.Threading.Tasks;
using HackerNews.Models;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace HackerNews.Repositories
{
    public class HackerNewsRepository : IHackerNewsRepository
    {
        public async  Task<int[]> GetBestStoriesIds()
        {
            try
            {
                string url = "https://hacker-news.firebaseio.com/v0/beststories.json";
                int[] ids = new int[600];
                var result = await clientAsync(url, ids);
                return result;
            }
            catch (HttpRequestException)
            {
                throw;
            }
        }

        public async Task< StoryModel> GetStory(int id)
        {
            try
            {
                StoryModel storyModel = new StoryModel();
                string url = "https://hacker-news.firebaseio.com/v0/item/" + id.ToString() + ".json";
                var result = await clientAsync(url, storyModel);
                return result;
            }
            catch (HttpRequestException )
            {
                throw;
            }
        }

        private async Task<T> clientAsync<T>(string url, T defaultValue)
        {
            var client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            };
            var bestStory = JsonSerializer.Deserialize<T>(responseBody, options);

            return bestStory;
        }
    }
}
