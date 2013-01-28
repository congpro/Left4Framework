using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Framework.Infrastructure;

/// <summary>
/// DependencyResolver 的摘要说明
/// </summary>
public class DependencyResolver
{
    public object GetService(Type serviceType)
    {
        return EngineContext.Current.ContainerManager.ResolveOptional(serviceType);
    }

    public IEnumerable<object> GetServices(Type serviceType)
    {
        var type = typeof(IEnumerable<>).MakeGenericType(serviceType);
        return (IEnumerable<object>)EngineContext.Current.Resolve(type);
    }
}