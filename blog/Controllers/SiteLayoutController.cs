using blog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper.Internal;
using Our.Umbraco.Ditto;
using Umbraco.Core;
using Umbraco.Web;
using Umbraco.Web.Mvc;

namespace blog.Controllers
{
    public class SiteLayoutController : SurfaceController
    {
        private const string PARTIALS_DIR = "~/Views/Partials/";
        private const string TAG_KEY = "POST_TAGS";
        private const string POPULAR_POST_KEY = "POPULAR POSTS";
        private const string TAG_GROUP = "default";
        
        public ActionResult RenderTags()
        {
            var blogTags = ApplicationContext.ApplicationCache.RuntimeCache
                .GetCacheItem(TAG_KEY, () =>
                {
                    var service = UmbracoContext.Application.Services.TagService;
                    return service.GetAllTags(TAG_GROUP)
                        .Where(x => x.DeletedDate.HasValue == false)
                        .OrderByDescending(x => x.NodeCount)
                        ;
                }, TimeSpan.FromSeconds(24 * 60 * 60 * 7.0)) as IEnumerable<Umbraco.Core.Models.ITag>; // 1 week

            //var service = UmbracoContext.Application.Services.TagService;
            //var blogTags = service.GetAllTags("default")
            //    .Where(x => x.DeletedDate.HasValue == false)
            //    .OrderByDescending(x => x.NodeCount)
            //    ;

            List<Tag> tags = null;

            if (blogTags != null && blogTags.Any())
                tags = blogTags.Select(x => new Tag
                {
                    Text = x.Text,
                    Count = x.NodeCount,
                    Size = SizedOfTags(x.NodeCount)
                })
                .ToList();            
            
            return PartialView(PARTIALS_DIR + "_Tags.cshtml", tags);
        }

        public ActionResult RenderPopularPost()
        {
            //var posts = CurrentPage.Site()
            //    .Children
            //    .Where(x => x.IsDraft == false && string.IsNullOrWhiteSpace(x.Name) == false)
            //    .OrderByDescending(x => x.GetPropertyValue<int>(Alias.ViewCount))
            //    .Take(5)
            //    .As<PreviewPostViewModel>();

            var posts = ApplicationContext.ApplicationCache.RuntimeCache
                .GetCacheItem(POPULAR_POST_KEY, () =>
                {
                    return CurrentPage.Site()
                        .Children
                        .Where(x => x.IsDraft == false && string.IsNullOrWhiteSpace(x.Name) == false)
                        .OrderByDescending(x => x.GetPropertyValue<int>(Alias.ViewCount))
                        .Take(5)
                        .As<PreviewPostViewModel>();
                }, TimeSpan.FromSeconds(24 * 60 * 60)) as IEnumerable<PreviewPostViewModel>; // 1 day

            return PartialView(PARTIALS_DIR + "_PopularPosts.cshtml", posts);
        }

        private static int SizedOfTags(int count)
        {
            if (count <= 3)
                return 0;

            if (count <= 7)
                return 1;

            if (count <= 10)
                return 2;

            return 3;
        }
    }
}