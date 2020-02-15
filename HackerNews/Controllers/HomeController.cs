using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HackerNews.Models;
using HackerNews.Services;
using HackerNews.ViewModels;
using cloudscribe.Pagination.Models;

namespace HackerNews.Controllers
{
    public class HomeController : Controller
    {
        public IHackerNewsService HackerNewsService { get; }

        public HomeController(IHackerNewsService hackerNewsService)
        {
            HackerNewsService = hackerNewsService;
        }
        public async Task<IActionResult> Index(int pageNumber =1, int pageSize=10, string Search="")
        {
            SingltonHomeStoryViewModel singltonHomeStoryViewModel = SingltonHomeStoryViewModel.Instsance;
            HomeStoryViewModel homeStoryViewModel = new HomeStoryViewModel();
            if (singltonHomeStoryViewModel.ListStoryModel == null)
            {
                singltonHomeStoryViewModel.ListStoryModel = await HackerNewsService.LoadStories();
            }
            
            homeStoryViewModel.PageNumber = pageNumber;
            homeStoryViewModel.PageSize = pageSize;
            homeStoryViewModel.ListStoryModel = HackerNewsService.GetStories(pageNumber, pageSize, Search);
            if (Search == "")
            {
                homeStoryViewModel.TotalItems = singltonHomeStoryViewModel.ListStoryModel.Count;
            }
            else
            {
                homeStoryViewModel.TotalItems = pageSize;
                var count = singltonHomeStoryViewModel.ListStoryModel.Where(x => x.Title.Contains(Search.Trim(), StringComparison.OrdinalIgnoreCase) ||
                                                                                   x.By.Contains(Search.Trim(), StringComparison.OrdinalIgnoreCase)).ToList().Count;
                if (count > 10)
                {
                    homeStoryViewModel.Message = "Please narrow your search. Only top 10 results are returned.";
                }
            }
            return View(homeStoryViewModel);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
