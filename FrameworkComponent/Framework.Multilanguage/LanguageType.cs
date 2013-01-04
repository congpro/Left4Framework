/***********************************************************************
 *  Copyright (C) 2011 Framework Corporation
 *  All rights reserved.
 * 
 *  Author:  Peter.Li
 *  Date:    2012-4-12 09:43:57
 *  Purpose: 
 * 
 * ***********************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Framework.Multilanguage
{
    public class LanguageType
    {
        private const string _langCookieKey = "_LanguageType";

        public static bool MultiLanguage
        {
            get { return HttpContext.Current.Request.Cookies[_langCookieKey] != null; }
        }

        /// <summary>
        /// 获取默认语言操作
        /// </summary>
        /// <param name="defaultLanguage">如果为空，返回defaultLanguage</param>
        /// <returns></returns>
        public static string GetCurrentLanguageType(string defaultLanguage)
        {
            HttpCookie c = HttpContext.Current.Request.Cookies[_langCookieKey];
            if (c == null)
            {
                if (!string.IsNullOrEmpty(defaultLanguage))
                {
                    SetCurrentLanguageType(defaultLanguage);
                }

                return defaultLanguage;
            }
            return c.Value;
        }
        /// <summary>
        /// 设置默认语言操作
        /// </summary>
        /// <param name="languageType"></param>
        public static void SetCurrentLanguageType(string languageType)
        {
            HttpCookie c = new HttpCookie(_langCookieKey, languageType);
            HttpContext.Current.Response.Cookies.Add(c);
        }
    }
}
