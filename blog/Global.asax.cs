using System;
using System.Web.Optimization;
using Umbraco.Core;
using Umbraco.Web;

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
        }
    }
}