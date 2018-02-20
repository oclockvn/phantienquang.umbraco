using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core.Models;

namespace blog.Helpers
{
    public static class UrlHelperExtends
    {
        public static string GetCanonicalUrl(this IPublishedContent content)
        {
            var canonicalUrl = String.Empty;

            if(umbraco.library.RequestServerVariables("HTTP_HOST").ToLower().StartsWith("www")) {
                canonicalUrl = string.Concat("http://", umbraco.library.RequestServerVariables("HTTP_HOST"), content.Url);
            } else {
                canonicalUrl = string.Concat("http://www.", umbraco.library.RequestServerVariables("HTTP_HOST"), content.Url);
            }

            return canonicalUrl;
        }
             
    }
}