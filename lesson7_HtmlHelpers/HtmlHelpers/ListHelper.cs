using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text;

namespace lesson7_HtmlHelpers.HtmlHelpers
{
	public static class ListHelper
	{
        public static HtmlString CreateList(this IHtmlHelper html, string[] items)
        {
            StringBuilder resultBuilder = new StringBuilder("<ul>");

            foreach (string item in items)
            {
                resultBuilder.Append($"<li>");
                resultBuilder.Append(item);
                resultBuilder.Append($"</li>");
            }

            resultBuilder.Append("</ul>");

            return new HtmlString(resultBuilder.ToString());
        }

    }
}
