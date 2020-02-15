using HackerNews.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HackerNews.ViewModels
{
    public class HomeStoryViewModel
    {
        public List<StoryModel> ListStoryModel { get; set; }
        public string PageTitle { get; set; }
    }
}
