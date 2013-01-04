/***********************************************************************
 *  Copyright (C) 2011 Framework Corporation
 *  All rights reserved.
 * 
 *  Author:  Peter.Li
 *  Date:    2011-10-18 09:43:57
 *  Purpose: 
 * 
 * ***********************************************************************/
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Collections.Specialized;

using Microsoft.Practices.EnterpriseLibrary.Data;


namespace Framework.DataAccess
{
    class SQLDataAccess : IDataBaseExecutor, IDataBaseTransactionHandler, IDataBaseAccess
    {
        private readonly DbConnection _connection;
        private IDbTransaction _transaction;
        protected const int DefaultCommandTimeout = 30;
        private bool _connectionIsNeedOpen;
        private int _commandTimeout;
        private static object o;
        private Database _dabtabase;

        #region 属性
 public SQLDataAccess()
        {
            this._dabtabase = this.GetDatabaseInstance();
        }

        public Database Dabtabase
        {
            get { return _dabtabase; }
            set { _dabtabase = value; }
        }


        protected DbConnection Connection
        {
            get { return this._connection; }
        }

        /// <summary>
        /// 获取当前连接使用的事务
        /// </summary>
        protected IDbTransaction Transaction
        {
            get
            {
                return this._transaction;
            }
        }

        /// <summary>
        /// 获取一个值，该值表示当前连接是否
        /// </summary>
        protected bool ConnectionIsNeedOpen
        {
            get
            {
                return this._connectionIsNeedOpen;
            }
        }

        /// <summary>
        /// 过期时间
        /// </summary>
        protected int CommandTimeout
        {
            get
            {
                return this._commandTimeout;
            }
        }
 #endregion

        protected Database GetDatabaseInstance()
        {
            //在并发时，使用单一对象
            if (this._dabtabase == null)
            {
                return DatabaseFactory.CreateDatabase();
            }
            else
            {
                lock (o)
                {
                    return _dabtabase;
                }
            }
        }


        #region IDataBaseExecutor 成员

        public virtual DataTable ExecuteDataTable(string commandText, CommandType type)
        {
            if (this._dabtabase != null)
            {
                return this._dabtabase.ExecuteDataSet(type, commandText).Tables[0];
            }
            else
            {
                return null;
            }
        }

        public virtual DataTable ExecuteDataTable(string commandText, params System.Data.IDataParameter[] pars)
        {
            if (this._dabtabase != null)
            {
                return this._dabtabase.ExecuteDataSet(commandText, pars).Tables[0];
            }
            else
            {
                return null;
            }
        }

        public virtual DataTable ExecuteDataTable(string commandText, System.Data.CommandType commandType, params System.Data.IDataParameter[] pars)
        {
            if (this._dabtabase != null)
            {
                return this._dabtabase.ExecuteDataSet(commandText, commandType, pars).Tables[0];
            }
            else
            {
                return null;
            }
        }





        public virtual DataSet ExecuteDataSet(DbTransaction transaction, string commandText)
        {
            if (this._dabtabase != null)
            {
                DbCommand cmd = this._dabtabase.GetSqlStringCommand(commandText);
                return this._dabtabase.ExecuteDataSet(cmd,transaction);
            }
            else
            {
                return null;
            }
        }

        public virtual DataSet ExecuteDataSet(string commandText, CommandType commandType)
        {
            if (this._dabtabase != null)
            {
                return this._dabtabase.ExecuteDataSet(commandType, commandText);
            }
            else
            {
                return null;
            }
        }

        public virtual DataSet ExecuteDataSet(string commandText, params System.Data.IDataParameter[] pars)
        {
            if (this._dabtabase != null)
            {
                return this._dabtabase.ExecuteDataSet(commandText, pars);
            }
            else
            {
                return null;
            }
        }

        public virtual DataSet ExecuteDataSet(string commandText, System.Data.CommandType commandType, params System.Data.IDataParameter[] pars)
        {
            if (this._dabtabase != null)
            {
                return this._dabtabase.ExecuteDataSet(commandText, commandType, pars);
            }
            else
            {
                return null;
            }
        }





        public virtual T ExecuteScalar<T>(string commandText, CommandType commandType)
        {
            return (T)Convert.ChangeType(this._dabtabase.ExecuteScalar(commandType,commandText), typeof(T));
        }

        public virtual T ExecuteScalar<T>(string commandText, params System.Data.IDataParameter[] pars)
        {
            return (T)Convert.ChangeType(this._dabtabase.ExecuteScalar(commandText, pars), typeof(T));
        }

        public virtual T ExecuteScalar<T>(string commandText, System.Data.CommandType commandType, params System.Data.IDataParameter[] pars)
        {
            return (T)Convert.ChangeType(this._dabtabase.ExecuteScalar(commandText, commandType, pars), typeof(T));
        }





        public virtual int ExecuteNonQuery(string commandText, CommandType commandtype)
        {
            return this._dabtabase.ExecuteNonQuery(commandtype,commandText);
        }

        public virtual int ExecuteNonQuery(string commondText, params IDataParameter[] pars)
        {
            return this._dabtabase.ExecuteNonQuery(commondText, pars);
        }

        public virtual int ExecuteNonQuery(string commandText, CommandType commandType, params IDataParameter[] pars)
        {
            return this._dabtabase.ExecuteNonQuery(commandText, commandType, pars);
        }




        public virtual NameValueCollection ExecuteEntity(string commandText, CommandType commandType)
        {
            return null;
        }

        public virtual NameValueCollection ExecuteEntity(string commandText, params System.Data.IDataParameter[] pars)
        {
            throw new NotImplementedException();
        }

        public virtual NameValueCollection ExecuteEntity(string commandText, System.Data.CommandType commandType, params System.Data.IDataParameter[] pars)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IDataBaseTransactionHandler 成员

        public virtual void BeginTransaction()
        {
            if (this._connectionIsNeedOpen)
            {
                this._connectionIsNeedOpen = false;
                this._connection.Open();
                this._transaction = this._connection.BeginTransaction();
            }
            else
                throw new Exception("Executor is in Transaction Mode!");
        }

        public virtual void CommitTransaction()
        {
            if (this._transaction != null)
            {
                this._transaction.Commit();
                this._connection.Close();
                this._connectionIsNeedOpen = true;
                this._transaction.Dispose();
                this._transaction = null;
            }
        }


        public virtual void RollbackTransaction()
        {
            if (this._transaction != null)
            {
                this._transaction.Rollback();
                this._connection.Close();
                this._connectionIsNeedOpen = true;
                this._transaction.Dispose();

                this._transaction = null;
            }
        }

        #endregion

        #region IDisposable 成员

        public void Dispose()
        {
            this._dabtabase = null;
        }

        #endregion

        #region IDataBaseAccess 成员

        public virtual IDataParameter CreateParameter(string name, object value)
        {
            name = name.Trim();

            if (!name.StartsWith("@"))
                name = "@" + name;

            Type type = value.GetType();
            SqlParameter par = null;

            if (type.Equals(typeof(int)) && Convert.ToInt32(value) == 0)
                par = new SqlParameter(name, Convert.ToInt32(0));
            else
                par = new SqlParameter(name, value);

            if (type.Equals(typeof(string)) && value.ToString().Length > 4000)
                par.SqlDbType = SqlDbType.Text;

            return par;
        }

        public virtual IDataParameter CreateParameter(string name, DbType type, object value)
        {
            IDataParameter param = CreateParameter(name, value);
            param.DbType = type;

            return param;
        }

        #endregion
    }
}
