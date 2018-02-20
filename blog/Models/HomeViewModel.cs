using Our.Umbraco.Ditto;
using PagedList;
using Umbraco.Core.Models;
using Umbraco.Web.Models;

namespace blog.Models
{
    public class HomeViewModel : RenderModel
    {
        public HomeViewModel(IPublishedContent content) : base(content)
        {
        }

        [CurrentContentAs]
        public BaseViewModel BaseInfo { get; set; }

        [CurrentContentAs]
        public Seo SeoInfo { get; set; }

        // public virtual IEnumerable<PreviewPostViewModel> Children { get; set; }
        public virtual IPagedList<PreviewPostViewModel> Posts { get; set; }
    }

    public class PreviewPostViewModel
    {
        [CurrentContentAs]
        public BaseViewModel BaseInfo { get; set; }
        
        //public virtual IEnumerable<string> Tags { get; set; }
        //public string Title { get; set; }
        public string Excerpt { get; set; }
    }
}