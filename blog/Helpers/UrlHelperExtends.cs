using System;
using Umbraco.Core.Models;

namespace blog.Helpers
{
    public static class UrlHelperExtends
    {
        public static string GetCanonicalUrl(this IPublishedContent content) => GetCanonicalUrl(content.Url);

        public static string GetCanonicalUrl(this string contentUrl)
        {
            var canonicalUrl = String.Empty;

            if (umbraco.library.RequestServerVariables("HTTP_HOST").ToLower().StartsWith("www"))
            {
                canonicalUrl = string.Concat("http://", umbraco.library.RequestServerVariables("HTTP_HOST"), contentUrl);
            }
            else
            {
                canonicalUrl = string.Concat("http://www.", umbraco.library.RequestServerVariables("HTTP_HOST"), contentUrl);
            }

            return canonicalUrl;
        }

    }
}