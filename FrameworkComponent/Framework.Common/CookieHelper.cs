/***********************************************************************
 *  Copyright (C) 2011 Framework Corporation
 *  All rights reserved.
 * 
 *  Author:  Peter.Li
 *  Date:    2011-10-22 09:43:57
 *  Purpose: 
 * 
 * ***********************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Web;

namespace Framework.Common
{
    /// <summary>
    /// 针对cookie操作类
    /// </summary>
    public class CookieHelper
    {
        public static DateTime DateTimeNull = DateTime.Parse("1900-01-01");

        public static void SetTripleDESEncryptedCookie(string cookiename, Hashtable ht)
        {
            CookieHelper.SetCookie(cookiename, ht, DateTimeNull, "TripleDES");
        }

        public static void SetTripleDESEncryptedCookie(string cookiename, Hashtable ht, DateTime expires)
        {
            CookieHelper.SetCookie(cookiename, ht, expires, "TripleDES");
        }

        public static void SetDESEncryptedCookie(string cookiename, Hashtable ht)
        {
            CookieHelper.SetCookie(cookiename, ht, DateTimeNull, "DES");
        }

        public static void SetDESEncryptedCookie(string cookiename, Hashtable ht, DateTime expires)
        {
            CookieHelper.SetCookie(cookiename, ht, expires, "DES");
        }

        private static void SetCookie(string cookieName, Hashtable ht, DateTime expires, string desType)
        {
            HttpCookie httpCookie = HttpContext.Current.Request.Cookies[cookieName];
            if (httpCookie == null)
            {
                httpCookie = new HttpCookie(cookieName);
            }
            if (expires != DateTimeNull)
            {
                httpCookie.Expires = expires;
            }
            foreach (string text in ht.Keys)
            {
                string text3;
                string text2 = text3 = "";
                if (desType.ToLower() == "des")
                {
                    text3 = Encryption.Encrypt(text);
                    text2 = Encryption.Encrypt((string)ht[text]);
                }
                else
                {
                    text3 = Encryption.EncryptTripleDES(text);
                    text2 = Encryption.EncryptTripleDES((string)ht[text]);
                }
                text3 = HttpContext.Current.Server.UrlEncode(text3);
                text2 = HttpContext.Current.Server.UrlEncode(text2);
                httpCookie.Values.Remove(text3);
                httpCookie.Values[text3] = text2;
            }
            HttpContext.Current.Response.Cookies.Set(httpCookie);
        }

        private static string GetCookie(string cookieName, string key, string desType)
        {
            if (desType.ToLower() == "des")
            {
                key = Encryption.Encrypt(key);
            }
            else
            {
                key = Encryption.EncryptTripleDES(key);
            }
            key = HttpContext.Current.Server.UrlEncode(key);
            HttpCookie httpCookie = HttpContext.Current.Request.Cookies[cookieName];
            string text = "";
            try
            {
                text = httpCookie[key];
                text = HttpContext.Current.Server.UrlDecode(text);
                if (desType.ToLower() == "des")
                {
                    text = Encryption.Decrypt(text);
                }
                else
                {
                    text = Encryption.DecryptTripleDES(text);
                }
            }   
            catch
            {
            }
            return text;
        }

        public static string GetTripleDESEncryptedCookieValue(string cookiename, string key)
        {
            return CookieHelper.GetCookie(cookiename, key, "TripleDES");
        }

        public static string GetDESEncryptedCookieValue(string cookiename, string key)
        {
            return CookieHelper.GetCookie(cookiename, key, "DES");
        }

        public static string GetCookie(string cookieName)
        {
            return CookieHelper.Cookie(false, cookieName);
        }

        public static string GetCookie(string cookieName, string subCookieName)
        {
            return CookieHelper.Cookie(false, cookieName, subCookieName);
        }

        /// <summary>
        /// 添加cookie
        /// </summary>
        /// <param name="cookieName">cookie名字</param>
        /// <param name="val">cookie值</param>
        /// <param name="expiresDate">cookie过期时间</param>
        public static void SetCookie(string cookieName, string val, DateTime expiresDate)
        {
            HttpCookie httpCookie = null;
            if (HttpContext.Current.Request.Cookies.Get(cookieName) == null)
            {
                httpCookie = new HttpCookie(cookieName);
            }
            else
            {
                httpCookie = HttpContext.Current.Request.Cookies[cookieName];
            }
            httpCookie.Value = val;
            httpCookie.Expires = expiresDate;
            HttpContext.Current.Response.Cookies.Set(httpCookie);
        }

        public static void SetCookie(string cookieName, string index, string val, DateTime expiresDate)
        {
            HttpCookie httpCookie = null;
            if (HttpContext.Current.Request.Cookies.Get(cookieName) == null)
            {
                httpCookie = new HttpCookie(cookieName);
            }
            else
            {
                httpCookie = HttpContext.Current.Request.Cookies[cookieName];
            }
            httpCookie[index] = val;
            httpCookie.Expires = expiresDate;
            HttpContext.Current.Response.Cookies.Set(httpCookie);
        }

        private static string Cookie(HttpCookie cookie)
        {
            string result;
            if (cookie == null)
            {
                result = null;
            }
            else
            {
                result = cookie.Value;
            }
            return result;
        }

        private static string Cookie(HttpCookie cookie, string subCookieName)
        {
            string result;
            if (cookie == null)
            {
                result = null;
            }
            else
            {
                result = cookie[subCookieName];
            }
            return result;
        }

        private static string Cookie(bool fromResponse, string cookieName)
        {
            HttpCookieCollection cookies;
            if (fromResponse)
            {
                cookies = HttpContext.Current.Response.Cookies;
            }
            else
            {
                cookies = HttpContext.Current.Request.Cookies;
            }
            return CookieHelper.Cookie(cookies[cookieName]);
        }

        private static string Cookie(bool fromResponse, string cookieName, string subCookieName)
        {
            HttpCookieCollection cookies;
            if (fromResponse)
            {
                cookies = HttpContext.Current.Response.Cookies;
            }
            else
            {
                cookies = HttpContext.Current.Request.Cookies;
            }
            return CookieHelper.Cookie(cookies[cookieName], subCookieName);
        }
    }

    public enum CookieType
    {
        shoppingcart=0,
        customer=1
    }
}

