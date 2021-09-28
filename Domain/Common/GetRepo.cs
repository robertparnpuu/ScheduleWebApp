using System;
using Microsoft.Extensions.DependencyInjection;

namespace Domain.Common
{
    public sealed class GetRepo 
    {
        internal readonly IServiceProvider Provider;
        internal static IServiceProvider ProviderInstance;
        public GetRepo() : this(null) { }
        public GetRepo(IServiceProvider p = null) => Provider = p ?? ProviderInstance;
        public static void SetProvider(IServiceProvider p) => ProviderInstance = p;
        public dynamic Instance(Type t)
        {
            var p = Provider;
            var c = p?.CreateScope();
            var s = c?.ServiceProvider;
            var r = s?.GetService(t);
            return r;
        }
        public dynamic Instance<TService>() => Instance(typeof(TService));

    }
}
