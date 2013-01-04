/******************************************************************************
 *  作者：       [Peter.Li]
 *  创建时间：   2012/4/25 18:01:25
 *
 *
 ******************************************************************************/

using Autofac;

namespace Framework.Infrastructure
{
    public interface IDependencyRegistrar
    {
        void Register(ContainerBuilder builder, ITypeFinder typeFinder);

        int Order { get; }
    }
}
