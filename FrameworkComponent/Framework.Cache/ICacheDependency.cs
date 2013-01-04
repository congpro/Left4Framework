/***********************************************************************
 *  Copyright (C) 2011 Framework Corporation
 *  All rights reserved.
 * 
 *  Author:  Peter.Li
 *  Date:    2011-10-18 09:43:57
 *  Purpose: 
 * 
 * ***********************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.Cache
{
    public interface ICacheDependency
    {
        /// <summary>
        /// 是否已过期
        /// </summary>
        bool IsExpired { get; }

        /// <summary>
        /// 重置缓存策略（相当于重新开始缓存）
        /// </summary>
        void Reset();
    }
}
