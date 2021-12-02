using System;
using Microsoft.Extensions.DependencyInjection;

namespace Tests.Domain.Repos
{
    public class MockServiceProvider :IServiceProvider
    {
        private readonly dynamic service;
        public MockServiceProvider(dynamic x) => service = x;
        public dynamic GetService(Type serviceType)
            => serviceType == typeof(IServiceScopeFactory) ? ReturnScopeFactory() : ReturnService();
        private dynamic ReturnService() => service;
        private dynamic ReturnScopeFactory() => new MockServiceScopeFactory(this);
    }
}