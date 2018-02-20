using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core;

namespace blog.Events
{
    public class PostEvent : ApplicationEventHandler
    {
        protected override void ApplicationStarted(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
            // Umbraco.Core.Services.

            base.ApplicationStarted(umbracoApplication, applicationContext);
        }
    }
}