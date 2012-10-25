using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace ViewsLab.Helpers
{
    public static class ImageLinkHelper
    {


        public static MvcHtmlString ImageLink(this HtmlHelper helper, string actionName, string imageUrl,
            string alternateText)
        {
            return ImageLink(helper, actionName, imageUrl, alternateText, null);

        }

        public static MvcHtmlString ImageLink(this HtmlHelper helper, string actionName, string imageUrl,
            string alternateText, object routeValues)
        {
            return ImageLink(helper, actionName, imageUrl, alternateText, routeValues, null, null);
        }

        public static MvcHtmlString ImageLink(this HtmlHelper helper, string actionName, string imageUrl,
            string alternateText, object routeValues, object linkHtmlAttributes, object imageHtmlAttributes)
        {
            var urlHelper = new UrlHelper(helper.ViewContext.RequestContext);
            var url = urlHelper.Action(actionName, routeValues);

            var linkTagBuilder = new TagBuilder("a");
            linkTagBuilder.MergeAttribute("href", url);
            linkTagBuilder.MergeAttributes(new RouteValueDictionary(linkHtmlAttributes));

            var imageTagBuilder = new TagBuilder("img");
            imageTagBuilder.MergeAttribute("src", imageUrl);
            imageTagBuilder.MergeAttribute("alt", alternateText);
            imageTagBuilder.MergeAttributes(new RouteValueDictionary(imageHtmlAttributes));

            linkTagBuilder.InnerHtml = imageTagBuilder.ToString(TagRenderMode.SelfClosing);

            return new MvcHtmlString(linkTagBuilder.ToString());
        }
    }
}