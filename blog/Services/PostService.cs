using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Umbraco.Core;
using Umbraco.Core.Models;
using Umbraco.Core.Services;
using Umbraco.Web;

namespace blog.Services
{
    public interface IPostService
    {
        // void UpdateViewCount(Guid nodeKey, int count);
        void UpdateViewCount(int nodeId);
    }

    public class PostService : IPostService
    {
        private readonly IContentService contentService;

        public PostService(IContentService contentService)
        {
            this.contentService = contentService;
        }

        // public void UpdateViewCount(Guid nodeKey, int count)
        public void UpdateViewCount(int nodeId)
        {
            var service = contentService; // ApplicationContext.Current.Services.ContentService;
            var content = service.GetById(nodeId);

            var viewCount = content.GetValue<int>("viewCount");
            content.SetValue("viewCount", viewCount + 1);
            service.Save(content);

            service.DisposeIfDisposable();
        }
    }
}