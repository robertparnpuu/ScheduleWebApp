using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Core.Extensions {
    public static class ShowHtml
    {
        public static IHtmlContent Show<TModel, TResult>(this IHtmlHelper<TModel> html,
            Expression<Func<TModel, TResult>> expression) => Show(html, expression, expression);

        public static IHtmlContent Show<TModel, TResult1, TResult2>(this IHtmlHelper<TModel> html,
            Expression<Func<TModel, TResult1>> label, Expression<Func<TModel, TResult2>> value)
        {
            var labelString = html.DisplayNameFor(label);
            var valueString = (value is null) ? getValue(html, label) : getValue(html, value);
            return html.Show(labelString, valueString);
        }

        public static IHtmlContent Show<TModel>(
            this IHtmlHelper<TModel> html, string label, string value)
        {
            if (html == null) throw new ArgumentNullException(nameof(html));
            var htmlStringsList = htmlStrings(html, label, value);
            return new HtmlContentBuilder(htmlStringsList);
        }

        internal static List<object> htmlStrings<TModel>(
            IHtmlHelper<TModel> html, string label, string value)
        {
            return getHtmlStrings(
                html.Raw(label),
                html.Raw(value)
            );
        }

        public static List<object> getHtmlStrings(object label, object value)
        {
            return new List<object>()
            {
                new HtmlString("<dt class=\"col-sm-2\">"),
                label,
                new HtmlString("</dt>"),
                new HtmlString("<dd class=\"col-sm-10\">"),
                value,
                new HtmlString("</dd>")
            };
        }

        internal static string getValue<TModel, TResult>(IHtmlHelper<TModel> html,
            Expression<Func<TModel, TResult>> expression)
        {
            var value = html.DisplayFor(expression);
            var writer = new System.IO.StringWriter();
            value.WriteTo(writer, HtmlEncoder.Default);
            return writer.ToString();
        }
    }
}






