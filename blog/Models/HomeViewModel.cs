using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Umbraco.Web;
using Umbraco.Web.Models;
using Our.Umbraco.Ditto;

namespace blog.Models
{
    public class HomeViewModel
    {
        [CurrentContentAs]
        public BaseViewModel BaseInfo { get; set; }

        [CurrentContentAs]
        public Seo SeoInfo { get; set; }

        public virtual IEnumerable<PreviewPostViewModel> Children { get; set; }
    }

    public class PreviewPostViewModel
    {
        [CurrentContentAs]
        public BaseViewModel BaseInfo { get; set; }

        public string Url { get; set; }
        //public virtual IEnumerable<string> Tags { get; set; }
        //public string Title { get; set; }
        public string Excerpt { get; set; }

        [UmbracoProperty("CreatorName")]
        public string Author { get; set; }

        [UmbracoProperty("CreateDate")]
        public string CreatedDate { get; set; }
    }
}