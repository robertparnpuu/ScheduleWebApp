using System;

namespace PageModels.Extensions {

    public class Link {

        public Link(string displayName, string relativeLink) : this(displayName, new Uri(relativeLink + "?handler=index", UriKind.Relative)) { }

        public Link(string displayName, Uri url, string propertyName = null) {
            DisplayName = displayName;
            Url = url;
            PropertyName = propertyName ?? displayName;
        }

        public string DisplayName { get; }
        public Uri Url { get; }
        public string PropertyName { get; }
    }
}