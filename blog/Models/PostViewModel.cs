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
        public int ViewCound { get; set; }
    }
}