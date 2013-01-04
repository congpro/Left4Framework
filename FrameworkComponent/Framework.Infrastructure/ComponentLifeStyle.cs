/******************************************************************************
 *  作者：       [Peter.Li]
 *  创建时间：   2012/4/25 17:29:43
 *
 *
 ******************************************************************************/
using System;

namespace Framework.Infrastructure
{
    public enum ComponentLifeStyle
    {
        Singleton = 0,
        Transient = 1,
        LifetimeScope = 2
    }
}
