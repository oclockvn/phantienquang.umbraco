using System.Web.Mvc;
using Umbraco.Core;
using Umbraco.Web.Mvc;

namespace blog.Controllers
{
    public class SettingDocTypeController : SurfaceController
    {
        [HttpPost]
        public ActionResult ClearCache(string code, string key)
        {
            if (string.IsNullOrWhiteSpace(code) == false && code == "1010") // :))
            {
                if (key == "all")
                {
                    ApplicationContext.ApplicationCache.RuntimeCache.ClearCacheItem(GlobalConstant.TagCacheKey);
                    ApplicationContext.ApplicationCache.RuntimeCache.ClearCacheItem(GlobalConstant.PopularPostCacheKey);
                }                    
                else if (string.IsNullOrWhiteSpace(key) == false)
                    ApplicationContext.ApplicationCache.RuntimeCache.ClearCacheItem(key);
            }

            return Redirect("~");
        }
    }
}