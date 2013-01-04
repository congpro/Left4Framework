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
using System.Data.SqlClient;
using System.Data.Common;

namespace Framework.DataAccess
{
     class SQLDataProvider : IDataProvider
    {
        private static SQLDataAccess access =new SQLDataAccess();

        public DataTable ExecuteDataTable(string commandText, CommandType commandType)
        {
            if (!string.IsNullOrEmpty(commandText))
            {
                return access.ExecuteDataTable(commandText,commandType);
            }
            return null;
        }

        public DataTable ExecuteDataTable(string StoredProcedureName, params System.Data.IDataParameter[] pars)
        {
            if (!string.IsNullOrEmpty(StoredProcedureName))
            {
                return access.ExecuteDataTable(StoredProcedureName, pars);
            }
            
            return null;
        }

        public DataTable ExecuteDataTable(string commandText, System.Data.CommandType commandType, params System.Data.IDataParameter[] pars)
        {
            if (!string.IsNullOrEmpty(commandText))
            {
                return access.ExecuteDataTable(commandText,commandType,pars);
            }
            return null;
        }

        public DataSet ExecuteDataSet(string commandText,CommandType commandType)
        {
            if (commandText!=null)
            {
                return access.ExecuteDataSet(commandText,commandType);
            }
            return null;
        }

        public DataSet ExecuteDataSet(string commandText,DbTransaction transaction)
        {
            if (commandText != null)
            {
                return access.ExecuteDataSet(transaction,commandText);
            }
            return null;
        }

        public DataSet ExecuteDataSet(string StoredProcedureName, IDataParameter[] pars)
        {
            if (!string.IsNullOrEmpty(StoredProcedureName))
            {
                return access.ExecuteDataSet(StoredProcedureName, pars);
            }
            return null;
        }

        public  DataSet ExecuteDataSet(string commandText, CommandType commandType, IDataParameter[] pars)
        {
            if (!string.IsNullOrEmpty(commandText))
            {
                return access.ExecuteDataSet(commandText, commandType, pars);
            }
            return null;
        }

        public T ExecuteScalar<T>(string commandText,CommandType commandType)
        {
            return access.ExecuteScalar<T>(commandText, commandType);
        }

        public T ExecuteScalar<T>(string commandText, IDataParameter[] pars)
        {
            return access.ExecuteScalar<T>(commandText, pars);
        }

        public T ExecuteScalar<T>(string commandText, CommandType commandType, params IDataParameter[] pars)
        {
            return access.ExecuteScalar<T>(commandText,commandType,pars);
        }

        public int ExecuteNonQuery(string commandText,CommandType commandType)
        {
            return access.ExecuteNonQuery(commandText, commandType);
        }

        public int ExecuteNonQuery(string StoredProcedureName, IDataParameter[] pars)
        {
            return access.ExecuteNonQuery(StoredProcedureName, pars);
        }

        public int ExecuteNonQuery(string commandText, System.Data.CommandType commandType, IDataParameter[] pars)
        {
            return access.ExecuteNonQuery(commandText, commandType, pars);
        }

        public System.Collections.Specialized.NameValueCollection ExecuteEntity(string commandText, CommandType commandType)
        {
            throw new NotImplementedException();
        }

        public System.Collections.Specialized.NameValueCollection ExecuteEntity(string commandText, params System.Data.IDataParameter[] pars)
        {
            throw new NotImplementedException();
        }

        public System.Collections.Specialized.NameValueCollection ExecuteEntity(string commandText, System.Data.CommandType commandType, params System.Data.IDataParameter[] pars)
        {
            throw new NotImplementedException();
        }

        #region IDataBaseTransactionHandler 成员

        public void BeginTransaction()
        {
            access.BeginTransaction();
        }

        public void CommitTransaction()
        {
            access.CommitTransaction();
        }

        public void RollbackTransaction()
        {
            access.RollbackTransaction();
        }

        #endregion

        #region IDisposable 成员

        public void Dispose()
        {
            Dispose();
        }

        #endregion

        public IDataParameter CreateParameter(string name, object value)
        {
          return  access.CreateParameter(name, value);
        }

        public IDataParameter CreateParameter(string name, DbType type, object value)
        {
            return access.CreateParameter(name,type,value);
        }
    }
}
