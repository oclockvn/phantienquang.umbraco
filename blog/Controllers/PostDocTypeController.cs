using blog.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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