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

namespace Framework.Common
{
    /// <summary>
    /// JSON相关的操作类
    /// </summary>
    public class JsonHelper
    {
        //json部分
        #region 字符串 类型的数据转换为 json格式
        /// <summary>
        /// 字符串类型的数据转换为 json格式
        /// </summary>
        /// <param name="value">要转换的字符串</param>
        /// <param name="sb">StringBuilder的实例，即json的容器</param>
        /// <returns></returns>
        public static void StringToJson(String value, StringBuilder sb)
        {
            sb.Append('\"');
            foreach (char c in value)
            {
                switch (c)
                {
                    case '\"':
                        sb.Append("\\\"");
                        break;
                    case '\\':
                        sb.Append("\\\\");
                        break;
                    case '/':
                        sb.Append("\\/");
                        break;
                    case '\b':
                        sb.Append("\\b");
                        break;
                    case '\f':
                        sb.Append("\\f");
                        break;
                    case '\n':
                        sb.Append("\\n");
                        break;
                    case '\r':
                        sb.Append("\\r");
                        break;
                    case '\t':
                        sb.Append("\\t");
                        break;
                    default:
                        sb.Append(c);
                        break;
                }
            }
            sb.Append('\"');
        }

        #endregion

        #region int 类型的数据转换为 json格式
        /// <summary>
        /// int 类型的数据转换为 json格式
        /// </summary>
        /// <param name="value">要转换的int</param>
        /// <param name="sb">StringBuilder的实例，即json的容器</param>
        /// <returns></returns>
        public static void IntToJson(int value, StringBuilder sb)
        {
            sb.Append(value);
        }
        #endregion

        #region Double 类型的数据转换为 json格式
        /// <summary>
        /// Double 类型的数据转换为 json格式
        /// </summary>
        /// <param name="value">要转换的double</param>
        /// <param name="sb">StringBuilder的实例，即json的容器</param>
        /// <returns></returns>
        public static void DoubleToJson(double value, StringBuilder sb)
        {
            sb.Append(value);
        }
        #endregion

        #region Bool 类型的数据转换为 json格式
        /// <summary>
        /// Bool 类型的数据转换为 json格式
        /// </summary>
        /// <param name="value">要转换的bool</param>
        /// <param name="sb">StringBuilder的实例，即json的容器</param>
        /// <returns></returns>
        public static void BoolToJson(bool value, StringBuilder sb)
        {
            sb.Append(value);
        }
        #endregion

        #region DateTime 类型的数据转换为 json格式
        /// <summary>
        /// DateTime 类型的数据转换为 json格式
        /// </summary>
        /// <param name="value">要转换的日期</param>
        /// <param name="sb">StringBuilder的实例，即json的容器</param>
        public static void DateTimeToJson(DateTime value, StringBuilder sb)
        {
            sb.Append('\"');
            sb.Append(value.ToString("yyyy-MM-dd HH:mm"));
            sb.Append('\"');

        }
        #endregion

        #region Array 类型的数据转换为 json格式
        /// <summary>
        /// 数组 类型的数据转换为 json格式
        /// </summary>
        /// <param name="array">要转换的数组</param>
        /// <param name="sb">StringBuilder的实例，即json的容器</param>
        public static void ArrayToJson(Object[] array, StringBuilder sb)
        {
            if (array.Length == 0)
            {
                sb.Append("[]");
                return;
            }

            sb.Append('[');
            foreach (Object o in array)
            {
                ObjectToJson(o, sb);
                sb.Append(',');
            }
            // 将最后添加的 ',' 变为 ']': 
            sb[sb.Length - 1] = ']';

        }
        #endregion

        #region Object 类型的数据转换为 json格式
        /// <summary>
        /// Object 类型的数据转换为 json格式
        /// </summary>
        /// <param name="o">要转换的Object</param>
        /// <param name="sb">StringBuilder的实例，即json的容器</param>
        public static void ObjectToJson(Object o, StringBuilder sb)
        {
            if (o == null)
                sb.Append("null");

            else if (o is String)
                StringToJson((String)o, sb);

            else if (o is int)
                IntToJson((int)o, sb);

            else if (o is double)
                DoubleToJson((double)o, sb);

            else if (o is Object[])
                ArrayToJson((Object[])o, sb);

            else if (o is Boolean)
                BoolToJson((Boolean)o, sb);

            else if (o is DateTime)
                DateTimeToJson((DateTime)o, sb);

        }

        #endregion 
    }
}
