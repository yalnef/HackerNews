using HackerNews.Models;
using HackerNews.ViewModels;
using NUnit.Framework;
using System.Collections.Generic;

namespace HackerNewsTest
{
    [TestFixture]
    public class UnitTest
    {
        [SetUp]
        public void Setup()
        {
            SingltonHomeStoryViewModel singltonHomeStoryViewModel = SingltonHomeStoryViewModel.Instsance;
            List<StoryModel> ListStoryModel = new List<StoryModel> { new StoryModel {By="IronMan",Id=1,Title="Save the world",Url="www.Marvel.com" },
                                                                     new StoryModel {By="Captin America",Id=2,Title="Save the world",Url="www.Marvel.com"  },
                                                                     new StoryModel {By="SpiderMan",Id=3,Title="Save the world",Url="www.Marvel.com"  } };
            singltonHomeStoryViewModel.ListStoryModel = ListStoryModel;
        }

        [Test]
        public void SingltonHomeStoryViewModel_IsSingletonTest_ReturnNotNull()
        {
            SingltonHomeStoryViewModel singltonHomeStoryViewModelNewInstance = SingltonHomeStoryViewModel.Instsance;
            foreach (var item in singltonHomeStoryViewModelNewInstance.ListStoryModel)
            {
                if (item.Id == 1)
                {
                    Assert.That(item.By, Is.EqualTo("IronMan") );
                }
                if (item.Id == 2)
                {
                    Assert.That(item.By, Is.EqualTo("Captin America"));
                }
                if (item.Id == 3)
                {
                    Assert.That(item.By, Is.EqualTo("SpiderMan"));
                }
            }
        }
        [Test]
        public void SingltonHomeStoryViewModel_Count_Increment()
        {
            SingltonHomeStoryViewModel singltonHomeStoryViewModelNewInstance = SingltonHomeStoryViewModel.Instsance;
            List<StoryModel> ListStoryModel2 = new List<StoryModel> { new StoryModel {By="Thanos",Id=4,Title="Distroy the world",Url="www.Marvel.com" },
                                                                     new StoryModel {By="Ronan",Id=5,Title="Distroy the world",Url="www.Marvel.com"  },
                                                                     new StoryModel {By="Nebula ",Id=6,Title="Distroy the world",Url="www.Marvel.com"  } };
            singltonHomeStoryViewModelNewInstance.ListStoryModel.AddRange(ListStoryModel2);
            Assert.That(singltonHomeStoryViewModelNewInstance.ListStoryModel.Count, Is.GreaterThan(3));
        }
    }
}