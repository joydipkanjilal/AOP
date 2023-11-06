using Castle.DynamicProxy;
using Microsoft.Extensions.Caching.Memory;

namespace Autofac.Demo
{
    public class MemoryCacheInterceptor : IInterceptor
    {
        private readonly IMemoryCache _memoryCache;

        public MemoryCacheInterceptor(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public void Intercept(IInvocation invocation)
        {
            var declaringType = invocation.Method.DeclaringType;
            var methodName = invocation.Method.Name;
            var name = $"{declaringType}_{methodName}";
            var args = string.Join(", ", invocation.Arguments.Select(arg => (arg ?? string.Empty).ToString()));
            var cacheKey = $"{name}|{args}";

            if (!_memoryCache.TryGetValue(cacheKey, out object? returnValue))
            {
                invocation.Proceed();
                returnValue = invocation.ReturnValue;
                _memoryCache.Set(cacheKey, returnValue, TimeSpan.FromMinutes(1));
            }
            else
            {
                invocation.ReturnValue = returnValue;
            }
        }
    }
}