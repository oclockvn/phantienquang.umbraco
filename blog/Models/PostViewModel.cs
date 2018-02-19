using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Umbraco.Web;
using Umbraco.Web.Models;
using Our.Umbraco.Ditto;

namespace blog.Models
{
    public class PostViewModel
    {
        [CurrentContentAs]
        public BaseViewModel BaseInfo { get; set; }

        [CurrentContentAs]
        public Seo SeoInfo { get; set; }

        public string BodyText { get; set; }
    }
}