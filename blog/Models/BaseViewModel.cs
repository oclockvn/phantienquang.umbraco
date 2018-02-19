using Our.Umbraco.Ditto;
using System.Collections.Generic;
using Umbraco.Web.Models;

namespace blog.Models
{
    public class BaseViewModel
    {
        public string PageTitle { get; set; }
        public virtual IEnumerable<string> Tags { get; set; }
        public string Url { get; set; }

        [UmbracoProperty("CreatorName")]
        public string Author { get; set; }

        [UmbracoProperty("CreateDate")]
        public string CreatedDate { get; set; }

        // todo: get author avatar
    }
}