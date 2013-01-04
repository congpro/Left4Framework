using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections.Specialized;
using System.Data.Common;

namespace Framework.DataAccess
{
    public interface IDataProvider
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


        DataTable ExecuteDataTable(string commandText, CommandType commandType);

        DataTable ExecuteDataTable(string StoredProcedureName, params IDataParameter[] pars);

        DataTable ExecuteDataTable(string commandText, System.Data.CommandType commandType, params IDataParameter[] pars);


        DataSet ExecuteDataSet(string commandText, CommandType commandType);

        DataSet ExecuteDataSet(string commandText, DbTransaction transaction);

        DataSet ExecuteDataSet(string StoredProcedureName, IDataParameter[] pars);

        DataSet ExecuteDataSet(string commandText, CommandType commandType, IDataParameter[] pars);

        T ExecuteScalar<T>(string commandText,CommandType commandType);

        T ExecuteScalar<T>(string commandText, params IDataParameter[] pars);

        T ExecuteScalar<T>(string commandText, CommandType commandType, params IDataParameter[] pars);

        int ExecuteNonQuery(string commandText, CommandType commandType);

        int ExecuteNonQuery(string StoredProcedureName, IDataParameter[] pars);

        int ExecuteNonQuery(string commandText, System.Data.CommandType commandType, IDataParameter[] pars);

        void BeginTransaction();

        void CommitTransaction();

        void RollbackTransaction();

    }
}
