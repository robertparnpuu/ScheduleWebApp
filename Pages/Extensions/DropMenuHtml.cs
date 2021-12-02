using System.Collections.Generic;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PageModels.Extensions {

    public static class DropMenuHtml {

        public static IHtmlContent DropMenu(this IHtmlHelper h, string name, params Link[] items) {
            var s = htmlStrings(name, items);

            return new HtmlContentBuilder(s);
        }

        internal static List<object> htmlStrings(string name, Link[] items) {
            var list = new List<object>();
            beginMenu(list, name);
            foreach (var item in items) addItem(list, item);
            endMenu(list);

            return list;
        }

        internal static void addItem(List<object> htmlStrings, Link item) {
            if (htmlStrings is null) return;
            if (item is null) return;
            var s = $"<a class='dropdown-item text-dark' href=\"{item.Url}\">{item.DisplayName}</a>";
            htmlStrings.Add(new HtmlString(s));
        }

        internal static void beginMenu(List<object> htmlStrings, string name) {
            if (htmlStrings is null) return;
            htmlStrings.Add(new HtmlString("<li class=\"nav-item dropdown\">"));
            htmlStrings.Add(new HtmlString(
                "<a class=\"nav-link text-dark dropdown-toggle\" href=\"#\" id=\"navbardrop\" data-toggle=\"dropdown\">"));
            htmlStrings.Add(new HtmlString(name));
            htmlStrings.Add(new HtmlString("</a>"));
            htmlStrings.Add(new HtmlString("<div class=\"dropdown-menu\">"));
        }

        internal static void endMenu(List<object> htmlStrings) {
            if (htmlStrings is null) return;
            htmlStrings.Add(new HtmlString("</div>"));
            htmlStrings.Add(new HtmlString("</li>"));
        }
    }
}
