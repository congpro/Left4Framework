/******************************************************************************
 *  作者：       [Peter.Li]
 *  创建时间：   2012/4/24 17:10:05
 *
 *
 ******************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.Infrastructure
{
    public interface IServices
    {
        ContainerManager ContainerManager { get; }

        /// <summary>
        /// Initialize components and plugins in the framework Environment.
        /// </summary>
        /// <param name="config">Config</param>
        void Initialize();

        T Resolve<T>() where T : class;

        object Resolve(Type type);

        Array ResolveAll(Type serviceType);

        T[] ResolveAll<T>();
    }
}
