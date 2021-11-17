using System;
using Microsoft.Extensions.DependencyInjection;

namespace Tests.Domain.Repos
{
    public class MockServiceScopeFactory :IServiceScopeFactory 
    {
        private readonly IServiceProvider provider;
        public MockServiceScopeFactory(IServiceProvider p) => provider = p;

        public IServiceScope CreateScope() => new MockServiceScope(provider);
    }
}