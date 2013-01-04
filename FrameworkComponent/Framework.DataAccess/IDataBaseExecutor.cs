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
using System.Collections.Specialized;
using System.Data;

namespace Framework.DataAccess
{
    public interface IDataBaseExecutor:IDataBaseTransactionHandler
    {
        /// <summary>
        /// 执行 SQL 文本命令查询，并返回包含查询结果的 DataTable 。
        /// </summary>
        /// <param name="commandText">要执行的查询的文本命令</param>
        /// <returns>包含查询结果的 DataTable 。</returns>
        DataTable ExecuteDataTable(string commandText, CommandType commandType);

        /// <summary>
        /// 执行 SQL 文本命令查询，并返回包含查询结果的 DataTable 。
        /// </summary>
        /// <param name="commandText">要执行的查询的文本命令</param>
        /// <param name="pars">commandText 中用到的参数集合</param>
        /// <returns>包含查询结果的 DataTable 。</returns>
        DataTable ExecuteDataTable(string commandText, params IDataParameter[] pars);

        /// <summary>
        /// 执行查询，并返回包含查询结果的 DataTable 。
        /// </summary>
        /// <param name="commandText">要执行的查询的文本命令</param>
        /// <param name="commandType">commandText 的类型</param>
        /// <param name="pars">commandText 中用到的参数集合</param>
        /// <returns>包含查询结果的 DataTable 。</returns>
        DataTable ExecuteDataTable(string commandText, CommandType commandType,params IDataParameter[] pars);

        /// <summary>
        /// 执行 SQL 文本命令查询，并返回包含查询结果的 DataSet 。
        /// </summary>
        /// <param name="commandText">要执行的查询的文本命令</param>
        /// <returns>包含查询结果的 DataSet 。</returns>
        DataSet ExecuteDataSet(string commandText, CommandType commandType);

        /// <summary>
        /// 执行 SQL 文本命令查询，并返回包含查询结果的 DataSet 。
        /// </summary>
        /// <param name="commandText">要执行的查询的文本命令</param>
        /// <param name="pars">commandText 中用到的参数集合</param>
        /// <returns>包含查询结果的 DataSet 。</returns>
        DataSet ExecuteDataSet(string commandText, params IDataParameter[] pars);

        /// <summary>
        /// 执行查询，并返回包含查询结果的 DataSet 。
        /// </summary>
        /// <param name="commandText">要执行的查询的文本命令</param>
        /// <param name="commandType">commandText 的类型</param>
        /// <param name="pars">commandText 中用到的参数集合</param>
        /// <returns>包含查询结果的 DataSet 。</returns>
        DataSet ExecuteDataSet(string commandText, CommandType commandType, params IDataParameter[] pars);

        /// <summary>
        /// 执行 SQL 文本命令查询，并返回查询所返回的结果集中第一行的第一列。所有其他的列和行将被忽略。
        /// </summary>
        /// <typeparam name="T">返回数据的数据类型</typeparam>
        /// <param name="commandText">要执行的查询的文本命令</param>
        /// <returns>结果集中第一行的第一列或空引用（如果结果集为空）。</returns>
        T ExecuteScalar<T>(string commandText, CommandType commandType);

        /// <summary>
        /// 执行SQL 文本命令查询，并返回查询所返回的结果集中第一行的第一列。所有其他的列和行将被忽略。
        /// </summary>
        /// <typeparam name="T">返回数据的数据类型</typeparam>
        /// <param name="commandText">要执行的查询的文本命令</param>
        /// <param name="pars">commandText 中用到的参数集合</param>
        /// <returns>结果集中第一行的第一列或空引用（如果结果集为空）。</returns>
        T ExecuteScalar<T>(string commandText, params IDataParameter[] pars);

        /// <summary>
        /// 执行查询，并返回查询所返回的结果集中第一行的第一列。所有其他的列和行将被忽略。
        /// </summary>
        /// <typeparam name="T">返回数据的数据类型</typeparam>
        /// <param name="commandText">要执行的查询的文本命令</param>
        /// <param name="commandType">commandText 的类型</param>
        /// <param name="pars">commandText 中用到的参数集合</param>
        /// <returns>结果集中第一行的第一列或空引用（如果结果集为空）。</returns>
        T ExecuteScalar<T>(string commandText, CommandType commandType, params IDataParameter[] pars);

        /// <summary>
        /// 执行 SQL 语句并返回受影响的行数。
        /// </summary>
        /// <param name="commandText">要执行的文本命令</param>
        /// <returns>受影响的行数。</returns>
        int ExecuteNonQuery(string commandText, CommandType commandType);

        /// <summary>
        /// 执行 SQL 语句并返回受影响的行数。
        /// </summary>
        /// <param name="commandText">要执行的文本命令</param>
        /// <param name="pars">commandText 中用到的参数集合</param>
        /// <returns>受影响的行数。</returns>
        int ExecuteNonQuery(string commandText, params IDataParameter[] pars);

        /// <summary>
        /// 执行 SQL 语句并返回受影响的行数。
        /// </summary>
        /// <param name="commandText">要执行的文本命令</param>
        /// <param name="commandType">commandText 的类型</param>
        /// <param name="pars">commandText 中用到的参数集合</param>
        /// <returns>受影响的行数。</returns>
        int ExecuteNonQuery(string commandText, CommandType commandType, params IDataParameter[] pars);

        /// <summary>
        /// 执行 SQL 语句并返回由执行结果第一行数据构造的 NameValueCollection。
        /// </summary>
        /// <param name="commandText">要执行的文本命令</param>
        /// <returns>执行结果第一行数据构造的 NameValueCollection</returns>
        NameValueCollection ExecuteEntity(string commandText,CommandType commandType);

        /// <summary>
        /// 执行 SQL 语句并返回由执行结果的第一行数据构造的 NameValueCollection。
        /// </summary>
        /// <param name="commandText">要执行的文本命令</param>
        /// <param name="pars">commandText 的类型</param>
        /// <returns>执行结果第一行数据构造的 NameValueCollection</returns>
        NameValueCollection ExecuteEntity(string commandText, params IDataParameter[] pars);

        /// <summary>
        /// 执行 SQL 语句并返回由执行结果的第一行数据构造的 NameValueCollection。
        /// </summary>
        /// <param name="commandText">要执行的文本命令</param>
        /// <param name="commandType">commandText 的类型</param>
        /// <param name="pars">commandText 中用到的参数集合</param>
        /// <returns>执行结果第一行数据构造的 NameValueCollection</returns>
        NameValueCollection ExecuteEntity(string commandText, CommandType commandType, params IDataParameter[] pars);
    }
   }
