/******************************************************************************
 *  作者：       [Peter.Li]
 *  创建时间：   2012/4/17 13:41:41
 *
 *
 ******************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Reflection;

namespace Framework.Infrastructure
{
    /// <summary>
    /// 注入容器类
    /// </summary>
    public class ServiceLocator
    {

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static IServices Initialize(bool forceRecreate)
        {
            return Singleton<IServices>.Instance;
        }

        /// <summary>Sets the static engine instance to the supplied engine. Use this method to supply your own engine implementation.</summary>
        /// <param name="engine">The engine to use.</param>
        /// <remarks>Only use this method if you know what you're doing.</remarks>
        public static void Replace(IServices service)
        {
            Singleton<IServices>.Instance = service;
        }

        /// <summary>
        /// Creates a factory instance and adds a http application injecting facility.
        /// </summary>
        /// <returns>A new factory</returns>
        public static IServices CreateEngineInstance(string engine)
        {
            if (string.IsNullOrEmpty(engine))
                return null;
            var engineType = Type.GetType(engine);
            if (engineType == null)
                throw new Exception(engine+"is null!");

            if (!(typeof(IServices).IsAssignableFrom(engineType)))
                throw new Exception(engineType + "doesn't implement !");

            return Activator.CreateInstance(engineType) as IServices;
        }

        /// <summary>Gets the singleton Nop engine used to access Nop services.</summary>
        public static IServices Current
        {
            get
            {
                if (Singleton<IServices>.Instance == null)
                {
                    Initialize(false);
                }
                return Singleton<IServices>.Instance;
            }
        }
    }
}
