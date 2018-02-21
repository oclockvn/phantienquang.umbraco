using blog.Services;
using System.Web.Mvc;
using Umbraco.Web.Models;
using Umbraco.Web.Mvc;

namespace blog.Controllers
{
    public class PostDocTypeController : RenderMvcController
    {
        public override ActionResult Index(RenderModel model)
        {
            IPostService postService = new PostService(Services.ContentService);
            postService.UpdateViewCount(model.Content.Id);

            return base.Index(model);
        }
    }
}