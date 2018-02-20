using blog.Models;
using Our.Umbraco.Ditto;
using PagedList;
using System.Linq;
using System.Web.Mvc;
using Umbraco.Web.Models;
using Umbraco.Web.Mvc;

namespace blog.Controllers
{
    public class HomeDocTypeController : RenderMvcController
    {
        public override ActionResult Index(RenderModel model)
        {
            if (int.TryParse(Request.Params["page"], out int page) == false)
                page = 1;
            int pageSize = 7;
            int pageNumber = page;

            var content = model.Content.Children
                .OrderByDescending(x => x.CreateDate)
                ;

            var posts = content.As<PreviewPostViewModel>()
                .ToPagedList(pageNumber, pageSize)
                ;

            var viewmodel = new HomeViewModel(model.Content)
            {
                Posts = posts
            };

            return base.Index(viewmodel);
        }
    }
}