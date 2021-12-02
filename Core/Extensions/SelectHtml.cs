using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Core.Extensions
{
    public static class SelectHtml
    {
        public static IHtmlContent Select<TModel, TResult>(this IHtmlHelper<TModel> html,
        Expression<Func<TModel, TResult>> expression, IEnumerable<SelectListItem> selectList, string optionLabel)
            => Select(html, expression, expression, selectList, optionLabel);

        public static IHtmlContent Select<TModel, TResult1, TResult2>(this IHtmlHelper<TModel> html,
        Expression<Func<TModel, TResult1>> label, Expression<Func<TModel, TResult2>> value, IEnumerable<SelectListItem> selectList, string optionLabel)
            => Select(html, value, selectList, optionLabel, getDisplayName(html, label));

        private static string getDisplayName<TModel, TResult>(IHtmlHelper<TModel> html,
        Expression<Func<TModel, TResult>> expression) => html.DisplayNameFor(expression);

        public static IHtmlContent Select<TModel, TResult>(this IHtmlHelper<TModel> html,
        Expression<Func<TModel, TResult>> expression, IEnumerable<SelectListItem> selectList, string optionLabel, string displayName)
        {
            var htmlStrings = getHtmlStrings(html, expression, selectList, optionLabel, displayName);
            return new HtmlContentBuilder(htmlStrings);
        }

        internal static List<object> getHtmlStrings<TModel, TResult>(IHtmlHelper<TModel> html,
        Expression<Func<TModel, TResult>> expression, IEnumerable<SelectListItem> selectList,
        string optionLabel, string displayName)
        {
            return new List<object>()
            {
            new HtmlString("<div class=\"form-group\">"),
            displayName,
            html.DropDownListFor(expression, selectList, optionLabel, new {@class = "form-control"}),
            html.ValidationMessageFor(expression, "", new {@class = "text-danger"}),
            new HtmlString("</div>")
            };
        }
    }
}
