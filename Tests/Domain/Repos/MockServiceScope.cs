using System;
using Microsoft.Extensions.DependencyInjection;

namespace Tests.Domain.Repos 
{
    public class MockServiceScope :IServiceScope
    {
        public MockServiceScope(IServiceProvider p) => ServiceProvider = p;
        public void Dispose() { }
        public IServiceProvider ServiceProvider { get; }
    }
}