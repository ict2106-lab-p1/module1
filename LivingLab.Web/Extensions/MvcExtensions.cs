using Microsoft.AspNetCore.Mvc.Rendering;

namespace LivingLab.Web.Extensions;

public static class MvcExtensions
{
    public static string ActiveClass(this IHtmlHelper htmlHelper, string controllers, string actions, string cssClass = "text-gray-700 bg-highlight")
    {
        var routeData = htmlHelper.ViewContext.RouteData;

        var routeAction = routeData.Values["action"].ToString();
        var routeController = routeData.Values["controller"].ToString();

        var returnActive = routeController == controllers ? cssClass : "text-gray-400";

        return returnActive;
    }
}
