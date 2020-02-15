﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HackerNews.Models
{
    public class StoryModel
    {
        public int Id { get; set; }
        public string By { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
    }
}
