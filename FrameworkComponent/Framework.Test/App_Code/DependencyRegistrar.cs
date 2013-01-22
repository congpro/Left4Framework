using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Autofac;
using Autofac.Integration.Mvc;
using Framework.DataAccess.ORM.FluentData;
using Framework.Infrastructure;
using Framework.DataAccess.ORM;
using Framework.Infrastructure.Fakes;

/// <summary>
/// 依赖注入注册容器类 的摘要说明
/// </summary>
public class DependencyRegistrar:IDependencyRegistrar
{

    public void Register(ContainerBuilder builder, ITypeFinder typeFinder)
    {
        //HTTP context and other related stuff
        builder.Register(c =>
            //register FakeHttpContext when HttpContext is not available
            HttpContext.Current != null ?
            (new HttpContextWrapper(HttpContext.Current) as HttpContextBase) :
            (new FakeHttpContext("~/") as HttpContextBase))
            .As<HttpContextBase>()
            .InstancePerHttpRequest();
        builder.Register(c => c.Resolve<HttpContextBase>().Request)
            .As<HttpRequestBase>()
            .InstancePerHttpRequest();
        builder.Register(c => c.Resolve<HttpContextBase>().Response)
            .As<HttpResponseBase>()
            .InstancePerHttpRequest();
        builder.Register(c => c.Resolve<HttpContextBase>().Server)
            .As<HttpServerUtilityBase>()
            .InstancePerHttpRequest();
        builder.Register(c => c.Resolve<HttpContextBase>().Session)
            .As<HttpSessionStateBase>()
            .InstancePerHttpRequest();


        builder.RegisterType<SqlServerProvider>().As<IDbProvider>();
    }

    public int Order
    {
        get { return 0; }
    }
}