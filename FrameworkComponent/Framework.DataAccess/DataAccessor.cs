/******************************************************************************
 *  作者：       [Peter.Li]
 *  创建时间：   2012-06-04 16:14:22
 *
 *
 ******************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;


namespace Framework.DataAccess
{
    /// <summary>
    /// 公用数据库属性抽象类
    /// </summary>
    public abstract class DataAccessor:IDisposable
    {

        /// <summary>
        /// 获取当前使用的连接对象
        /// </summary>
        public virtual DbConnection Connection
        {
            get;
            protected set;
        }

        /// <summary>
        /// 获取或设置是否每次都使用同一个数据库连接对象。
        /// </summary>
        public virtual bool SingletonConnection
        {
            get;
            set;
        }

        /// <summary>
        /// 获取当前实现的数据库类型
        /// </summary>
        public abstract string DBMS
        {
            get;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
