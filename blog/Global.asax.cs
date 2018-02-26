using System;
using System.Web.Optimization;
using Umbraco.Core;
using Umbraco.Web;
using Umbraco.Web.Models;
using Umbraco.Core.Models;
using System.Linq;
using umbraco.cms.businesslogic.web;
using blog.Models;
using System.Text.RegularExpressions;

namespace blog
{
    //public class Global : UmbracoApplication
    //{
    //    protected override void OnApplicationStarted(object sender, EventArgs e)
    //    {
    //        base.OnApplicationStarted(sender, e);
    //        BundleConfig.RegisterBundles(BundleTable.Bundles);
    //    }
    //}

    public class Bootstrapper : IApplicationEventHandler
    {
        public void OnApplicationInitialized(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {

        }

        public void OnApplicationStarting(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
            
        }

        public void OnApplicationStarted(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            Umbraco.Core.Services.ContentService.Saving += ContentService_Saving;
        }

        private void ContentService_Saving(Umbraco.Core.Services.IContentService sender, Umbraco.Core.Events.SaveEventArgs<Umbraco.Core.Models.IContent> e)
        {
            if (UmbracoContext.Current?.IsFrontEndUmbracoRequest ?? true)
                return;

            foreach (var entity in e.SavedEntities)
            {
                if (entity.HasProperty(Alias.BodyText))
                {
                    const string img = "<img alt='$1' data-src='$2' src='data:image/gif;base64,R0lGODdhAQABAPAAAMPDwwAAACwAAAAAAQABAAACAkQBADs='>";
                    const string pattern = @"!\[(.*)\]\((.*)\)"; // ![image alt](http://path/to/img)

                    var body = entity.GetValue<string>(Alias.BodyText);
                    if (string.IsNullOrWhiteSpace(body) == false && Regex.IsMatch(body, pattern))
                    {
                        var replacement = Regex.Replace(body, pattern, img, RegexOptions.Multiline);
                        entity.SetValue(Alias.BodyText, replacement);
                    }
                }
            }            
        }
    }
}