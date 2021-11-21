using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Aids;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Core.Extensions {
    public static class IndexTableHtml {
        internal static int defaultHeight = 50; 
        public static IHtmlContent RowButtons<TModel>(
            this IHtmlHelper<TModel> _, string pageUrl, string itemId,
            params string[] labels) {
            labels = setDefaultLabels(labels);
            var s = TableData(
                   RowButton(itemId, pageUrl, "Index", "Index", labels[0]),
                   RowButton(itemId, pageUrl, "Edit", "Edit", labels[1]),
                   RowButton(itemId, pageUrl, "Details", "Details", labels[2]),
                   RowButton(itemId, pageUrl,"Delete", "Delete", labels[3])
                );
            return new HtmlContentBuilder(s);
        }
        public static IHtmlContent RowData<TModel, TResult>(
            this IHtmlHelper<TModel> h, 
            Expression<Func<TModel, TResult>> data) {
            var s = TableData(h.DisplayFor(data));
            return new HtmlContentBuilder(s);
        }
        public static IHtmlContent TableHeader<TModel, TResult>(
            this IHtmlHelper<TModel> h,
            Expression<Func<TModel, TResult>> data) {
            var s = HeaderData(h.DisplayNameFor(data));
            return new HtmlContentBuilder(s);
        }
        public static IHtmlContent TableSortHeader<TModel, TResult>(
            this IHtmlHelper<TModel> h,
            Expression<Func<TModel, TResult>> data, IBaseModel p) {
            var s = h.SortHeaderData(data, p);
            return new HtmlContentBuilder(s);
        }
        public static List<object> SortHeaderData<TModel, TResult>(this IHtmlHelper<TModel> h, 
            Expression<Func<TModel, TResult>> e, IBaseModel p) {
            var sortOrder = GetMember.Name(e);
            if (p.SortOrder.StartsWith(sortOrder)) sortOrder = p.SortOrder;
            var uri = new Uri($"../{p.PageUrl}/Index", UriKind.Relative);
            var l = new List<object> {
                new HtmlString("<th>"),
                new HtmlString($"<a href=\"{uri}?"),
                new HtmlString("handler=Index&"),
                new HtmlString($"sortOrder={sortOrder}&"),
                new HtmlString($"currentFilter={p.CurrentFilter}&"),
                new HtmlString($"searchString={p.SearchString}&"),
                new HtmlString($"pageIndex={p.PageIndex}\""),
                new HtmlString(">"),
                new HtmlString("<span style=\"font-weight:normal\">"),
                h.DisplayNameFor(e),
                new HtmlString("</span>"),
                new HtmlString("</a>"),
                new HtmlString("</th>")
            };
            return l;
        }
        public static IHtmlContent RowData<TModel>(
            this IHtmlHelper<TModel> h,
            string data) {
            var s = TableData(h.Raw(data));
            return new HtmlContentBuilder(s);
        }
        public static IHtmlContent RowImage<TModel>(
            this IHtmlHelper<TModel> _,
            string imageStr, int? height = null) {
            var s = TableData(
                new HtmlString(
                    $"<img src=\"{imageStr}\" alt=\"not uploaded\" "+
                    $"height={height??defaultHeight} />"
                    )
                );
            return new HtmlContentBuilder(s);
        }

        internal static string[] setDefaultLabels(string[] handlers) {
            var l = new List<string>(handlers);
            if (l.Count == 0) l.Add(null);
            if (l.Count == 1) l.AddRange(
                new[] {"Edit", "Details", "Delete"});
            return l.ToArray();
        }
        public static IHtmlContent RowButton(string itemId,
            string pageUrl, string action, string handler, string caption) {
            var uri = new Uri($"../{pageUrl}/{action}", UriKind.Relative);
            return new HtmlString(
                (caption is null) 
                    ? string.Empty
                    : $"<a id=\"{action}Btn\" "+
                      $"href=\"{uri}?handler={handler}&id={itemId}\">"+
                      "<span style=\"font-weight:normal\">"+
                      $"{caption}</span></a> "
            );
        }
        public static List<object> TableData(params IHtmlContent[] data) {
            var l = new List<object> {new HtmlString("<td>")};
            l.AddRange(data);
            l.Add(new HtmlString("</td>"));
            return l;
        }
        public static List<object> HeaderData(params object[] data) {
            var l = new List<object> { new HtmlString("<th>") };
            l.AddRange(data);
            l.Add(new HtmlString("</th>"));
            return l;
        }
    }
}
