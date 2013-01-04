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
using System.Web;
using System.Web.UI.HtmlControls;
using System.Text.RegularExpressions;
using System.Web.Hosting;
using System.IO;
using System.Net;

namespace Framework.Common
{
    public static class UtilsHelper
    {
        public static string emailReg = @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
        public static string mobileReg = @"^(13[0-9]|15[0|1|2|3|6|7|8|9]|18[7|8|9])\d{8}$";
        public static string dateReg = "^\\d{4}-\\d{1,2}-\\d{1,2}$";


        /// <summary>
        /// 读cookie值
        /// </summary>
        /// <param name="strName">名称</param>
        /// <returns>cookie值</returns>
        public static string GetCookie(string strName)
        {
            if (HttpContext.Current.Request.Cookies != null && HttpContext.Current.Request.Cookies[strName] != null)
                return HttpContext.Current.Request.Cookies[strName].Value.ToString();

            return "";
        }

        /// <summary>
        /// 读cookie值
        /// </summary>
        /// <param name="strName">名称</param>
        /// <returns>cookie值</returns>
        public static string GetCookie(string strName, string key)
        {
            if (HttpContext.Current.Request.Cookies != null && HttpContext.Current.Request.Cookies[strName] != null && HttpContext.Current.Request.Cookies[strName][key] != null)
                return HttpContext.Current.Request.Cookies[strName][key].ToString();

            return "";
        }

        /// <summary>
        /// 写cookie值
        /// </summary>
        /// <param name="strName">名称</param>
        /// <param name="strValue">值</param>
        public static void WriteCookie(string strName, string strValue)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[strName];
            if (cookie == null)
            {
                cookie = new HttpCookie(strName);
            }
            cookie.Value = strValue;
            HttpContext.Current.Response.AppendCookie(cookie);
        }

        /// <summary>
        /// 写cookie值
        /// </summary>
        /// <param name="strName">名称</param>
        /// <param name="strValue">值</param>
        public static void WriteCookie(string strName, string key, string strValue)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[strName];
            if (cookie == null)
            {
                cookie = new HttpCookie(strName);
            }
            cookie[key] = strValue;
            HttpContext.Current.Response.AppendCookie(cookie);
        }

        /// <summary>
        /// 写cookie值
        /// </summary>
        /// <param name="strName">名称</param>
        /// <param name="strValue">值</param>
        /// <param name="strValue">过期时间(分钟)</param>
        public static void WriteCookie(string strName, string strValue, int expires)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[strName];
            if (cookie == null)
            {
                cookie = new HttpCookie(strName);
            }
            cookie.Value = strValue;
            cookie.Expires = DateTime.Now.AddMinutes(expires);
            HttpContext.Current.Response.AppendCookie(cookie);
        }

        /// <summary>
        /// 获得当前绝对路径
        /// </summary>
        /// <param name="strPath">指定的路径</param>
        /// <returns>绝对路径</returns>
        public static string GetMapPath(string strPath)
        {
            if (HttpContext.Current != null)
            {
                return HttpContext.Current.Server.MapPath(strPath);
            }
            else //非web程序引用
            {
                return System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, strPath);
            }
        }

        /// <summary>
        /// 替换sql语句中的有问题符号
        /// </summary>
        public static string ChkSQL(string str)
        {
            if (!string.IsNullOrEmpty(str))
                return str.Replace("'", "''");
            return "";
        }


        /// <summary>
        /// JS提示并返回
        /// </summary>
        /// <param name="str"></param>
        public static void JsAlert(string str)
        {
            HttpContext.Current.Response.Write("<script>alert('" + str + "');history.go(-1);</script>");
            HttpContext.Current.Response.End();
        }

        /// <summary>
        /// JS提示并跳转
        /// </summary>
        /// <param name="str"></param>
        /// <param name="url"></param>
        public static void JsAlert(string str, string url)
        {
            HttpContext.Current.Response.Write("<script>alert('" + str + "');window.location.href='" + url + "';</script>");
            HttpContext.Current.Response.End();
        }

        /// <summary>
        /// Verifies that a string is in valid e-mail format
        /// </summary>
        /// <param name="email">Email to verify</param>
        /// <returns>true if the string is a valid e-mail address and false if it's not</returns>
        public static bool IsValidEmail(string email)
        {
            bool result = false;
            if (String.IsNullOrEmpty(email))
                return result;
            email = email.Trim();
            result = Regex.IsMatch(email, emailReg);
            return result;
        }

        /// <summary>
        /// Get URL referrer
        /// </summary>
        /// <returns>URL referrer</returns>
        public static string GetUrlReferrer(HttpContext _httpContext)
        {
            string referrerUrl = string.Empty;

            if (_httpContext != null &&
                _httpContext.Request != null &&
                _httpContext.Request.UrlReferrer != null)
                referrerUrl = _httpContext.Request.UrlReferrer.ToString();

            return referrerUrl;
        }

        /// <summary>
        /// Get context IP address
        /// </summary>
        /// <returns>URL referrer</returns>
        public static string GetCurrentIpAddress(HttpContext _httpContext)
        {
            if (_httpContext != null &&
                    _httpContext.Request != null &&
                    _httpContext.Request.UserHostAddress != null)
                return _httpContext.Request.UserHostAddress;
            else
                return string.Empty;
        }


        private static AspNetHostingPermissionLevel? _trustLevel = null;
        /// <summary>
        /// Finds the trust level of the running application (http://blogs.msdn.com/dmitryr/archive/2007/01/23/finding-out-the-current-trust-level-in-asp-net.aspx)
        /// </summary>
        /// <returns>The current trust level.</returns>
        public static AspNetHostingPermissionLevel GetTrustLevel()
        {
            if (!_trustLevel.HasValue)
            {
                //set minimum
                _trustLevel = AspNetHostingPermissionLevel.None;

                //determine maximum
                foreach (AspNetHostingPermissionLevel trustLevel in
                        new AspNetHostingPermissionLevel[] {
                                AspNetHostingPermissionLevel.Unrestricted,
                                AspNetHostingPermissionLevel.High,
                                AspNetHostingPermissionLevel.Medium,
                                AspNetHostingPermissionLevel.Low,
                                AspNetHostingPermissionLevel.Minimal 
                            })
                {
                    try
                    {
                        new AspNetHostingPermission(trustLevel).Demand();
                        _trustLevel = trustLevel;
                        break; //we've set the highest permission we can
                    }
                    catch (System.Security.SecurityException)
                    {
                        continue;
                    }
                }
            }
            return _trustLevel.Value;
        }

        /// <summary>
        /// 虚拟路径映射成物理路径
        /// </summary>
        /// <param name="path">The path to map. E.g. "~/bin"</param>
        /// <returns>The physical path. E.g. "c:\inetpub\wwwroot\bin"</returns>
        public static string MapPath(string path)
        {
            if (HostingEnvironment.IsHosted)
            {
                //hosted
                return HostingEnvironment.MapPath(path);
            }
            else
            {
                //not hosted. For example, run in unit tests
                string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                path = path.Replace("~/", "").TrimStart('/').Replace('/', '\\');
                return Path.Combine(baseDirectory, path);
            }
        }

        /// <summary>
        /// 以post的方式向服务器发送数据
        /// </summary>
        /// <param name="data"></param>
        /// <param name="_url"></param>
        /// <returns></returns>
        public static string PostDataToServer(string data, string _url, PageEncode pageEncode)
        {
            string text = "POST";
            string result;
            try
            {
                HttpWebRequest httpWebRequest = WebRequest.Create(_url) as HttpWebRequest;
                string a;
                byte[] bytes = null;
                if ((a = text) != null)
                {
                    if (!(a == "GET"))
                    {
                        if (a == "POST")
                        {
                            httpWebRequest.Method = "POST";

                            switch (pageEncode)
                            {
                                case PageEncode.utf8:
                                    bytes = Encoding.UTF8.GetBytes(data);
                                    httpWebRequest.ContentType = "application/xml;charset=utf-8";
                                    break;
                                case PageEncode.gb2312:
                                    bytes = Encoding.GetEncoding("gb2312").GetBytes(data);
                                    httpWebRequest.ContentType = "application/xml;charset=gb2312";
                                    break;
                                default:
                                    bytes = Encoding.UTF8.GetBytes(data);
                                    httpWebRequest.ContentType = "application/xml;charset=utf-8";
                                    break;
                            }
                            httpWebRequest.ContentLength = (long)bytes.Length;
                            Stream requestStream = httpWebRequest.GetRequestStream();
                            requestStream.Write(bytes, 0, bytes.Length);
                            requestStream.Close();
                        }
                    }
                    else
                    {
                        httpWebRequest.Method = "GET";
                    }
                }
                HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                Stream responseStream = httpWebResponse.GetResponseStream();
                StreamReader streamReader = new StreamReader(responseStream);
                string text2 = streamReader.ReadToEnd();
                streamReader.Close();
                responseStream.Close();
                httpWebResponse.Close();
                result = text2;
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        /// <summary>
        /// 以特定的方式url编码
        /// </summary>
        /// <param name="url"></param>
        /// <param name="pageEncode"></param>
        /// <returns></returns>
        public static string UrlEncode(string url,PageEncode pageEncode)
        {
            byte[] bytes = null;
            if (pageEncode==PageEncode.gb2312)
            {
                bytes = Encoding.GetEncoding("gb2312").GetBytes(url);
            }

            if (pageEncode==PageEncode.utf8)
            {
                bytes = Encoding.UTF8.GetBytes(url);
            }
            
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                if (bytes[i] < 128)
                {
                    stringBuilder.Append((char)bytes[i]);
                }
                else
                {
                    stringBuilder.Append("%" + bytes[i++].ToString("x").PadLeft(2, '0'));
                    stringBuilder.Append("%" + bytes[i].ToString("x").PadLeft(2, '0'));
                }
            }
            return stringBuilder.ToString();
        }

        public enum PageEncode
        {
            utf8,
            gb2312
        }


        /// <summary>
        /// 生成无重复的优惠码
        /// </summary>
        /// <param name="codenumbers">生成优惠码的个数</param>
        /// <param name="codecount">生成优惠码的长度</param>
        /// <returns></returns>
        public static string[] Generate_promotion_code(int codenumbers, int codecount)
        {
            string charlist = "0,1,2,3,4,5,6,7,8,9,A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z";

            string[] codelist = charlist.Split(',').ToArray();

            //用来接收生成的优惠码
            string[] promotion_codes = new string[codenumbers];

            string[] exclude_codes_array = new string[codenumbers];

            Random rand = new Random();

            for (int i = 0; i < codenumbers; i++)
            {
                //List<string> code = new List<string>();

                string code = "";
                for (int j = 0; j < codecount; j++)
                {
                    code = codelist[rand.Next(0,codelist.Length-1)];
                }

                if (!promotion_codes.Contains(code))
                {
                    if (!exclude_codes_array.Contains(code))
                    {

                        promotion_codes[i] = code;
                    }
                    else
                    {
                        i--;
                    }
                }
                else
                {
                    i--;
                }
            }
            
            return promotion_codes;
        }

    }
}
