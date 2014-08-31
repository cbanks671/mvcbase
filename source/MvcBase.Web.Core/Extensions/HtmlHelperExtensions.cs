using System.Web.Mvc;
using MvcBase.Web.Core.Helpers;

namespace MvcBase.Web.Core.Extensions
{
    public static class HtmlHelperExtensions
    {
        public static UserHtmlHelper User(this HtmlHelper html)
        {
            return new UserHtmlHelper(html, new UrlHelper(html.ViewContext.RequestContext));
        }
    }
}