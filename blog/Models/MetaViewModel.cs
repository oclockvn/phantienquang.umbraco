using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace blog.Models
{
    public class MetaViewModel
    {
        public bool IsHomepage { get; set; }
        public string Type => IsHomepage ? "website" : "article";

        public string Description { get; set; }
        public string Keywords { get; set; }
        public string PageDescription { get; set; }
        public string PageTitle { get; set; }

        // 2018-02-20T17:29:59+01:00
        public DateTimeOffset PublishedTime { get; set; }
        public DateTimeOffset ModifiedTime { get; set; }

        public string Url { get; set; }
        public string UrlFeed { get; set; }
        public string UrlNext { get; set; }
        public string Canonical { get; set; }
        public string Author { get; set; }
        public string ShortLink { get; set; }
        public string OriginalSource { get; set; }
    }
}