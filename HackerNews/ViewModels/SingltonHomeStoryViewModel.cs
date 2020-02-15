using HackerNews.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HackerNews.ViewModels
{
    public class SingltonHomeStoryViewModel
    {
        static SingltonHomeStoryViewModel _instance;
        private SingltonHomeStoryViewModel() { }
        public static SingltonHomeStoryViewModel Instsance { get { return _instance ?? (_instance = new SingltonHomeStoryViewModel()); } }
        public List<StoryModel> ListStoryModel { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public int TotalItems { get; set; }
    }
}
