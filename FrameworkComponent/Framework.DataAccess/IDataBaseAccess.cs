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
using System.Data;
using System.Collections;
using System.Collections.Specialized;

namespace Framework.DataAccess
{
    interface IDataBaseAccess:IDataBaseTransactionHandler,IDataBaseExecutor
    {
        /// <summary>
        /// 构造参数
        /// </summary>
        /// <param name="name">参数名称</param>
        /// <param name="value">参数的值</param>
        /// <returns>可用于执行的参数</returns>
        IDataParameter CreateParameter(string name, object value);

        /// <summary>
        /// 构造参数
        /// </summary>
        /// <param name="name">参数名称</param>
        /// <param name="value">参数的值</param>
        /// <returns>可用于执行的参数</returns>
        IDataParameter CreateParameter(string name, DbType type, object value);

    }
}
