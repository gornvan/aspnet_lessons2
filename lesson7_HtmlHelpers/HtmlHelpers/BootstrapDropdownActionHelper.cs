using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text;

namespace lesson7_HtmlHelpers.HtmlHelpers
{
    public static class BootstrapDropdownActionHelper
    {
        const string _template_without_lis =
                """
            <div class="dropdown">
              <button class="btn btn-secondary dropdown-toggle" type="button" id="dropdownMenuButton1" data-bs-toggle="dropdown" aria-expanded="false">
              Dropdown button
              </button>
              <ul class="dropdown-menu" aria-labelledby="dropdownMenuButton1">
                {0}
              </ul>
            </div>
            """;

        /// <summary>
        /// Do not confuse with Dropdown Select!
        /// This is for selectable ACTION, not for selecting data.
        /// </summary>
        public static HtmlString CreateDropdownActoinButton(this IHtmlHelper html, string[] items)
        {
            StringBuilder listItems = new StringBuilder();

            foreach (var item in items)
            {
                listItems.Append("<li class=\"dropdown-item\" href=\"#\">");
                listItems.Append(item);
                listItems.Append("</li>");
            }

            string dropdownHtml = string.Format(_template_without_lis, listItems.ToString());

            return new HtmlString(dropdownHtml);
        }
    }
}
