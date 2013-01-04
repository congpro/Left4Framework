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

namespace Framework.DataAccess
{
    /// <summary>
    /// 事务处理接口
    /// </summary>
    public interface IDataBaseTransactionHandler:IDisposable
    {
        /// <summary>
        /// 开始事务处理。
        /// </summary>
        void BeginTransaction();

        /// <summary>
        /// 提交事务。
        /// </summary>
        void CommitTransaction();

        /// <summary>
        /// 回滚事务。
        /// </summary>
        void RollbackTransaction();
    }
}
