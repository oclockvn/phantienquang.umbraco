using blog.Models;
using Umbraco.Core;
using Umbraco.Core.Services;

namespace blog.Services
{
    public interface IPostService
    {
        // void UpdateViewCount(Guid nodeKey, int count);
        void UpdateViewCount(int nodeId);
    }

    public class PostService : IPostService
    {
        private readonly IContentService _contentService;

        public PostService(IContentService contentService)
        {
            _contentService = contentService;
        }

        // public void UpdateViewCount(Guid nodeKey, int count)
        public void UpdateViewCount(int nodeId)
        {
            var service = _contentService; // ApplicationContext.Current.Services.ContentService;
            var content = service.GetById(nodeId);

            var viewCount = content.GetValue<int>(Alias.ViewCount);
            content.SetValue(Alias.ViewCount, viewCount + 1);
            service.SaveAndPublishWithStatus(content);

            service.DisposeIfDisposable();
        }
    }
}