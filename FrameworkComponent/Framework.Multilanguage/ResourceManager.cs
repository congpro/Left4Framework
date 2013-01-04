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
using System.Collections.Specialized;
using System.Xml;
using System.Web.Caching;
using System.Web;
using System.Collections;
using System.Globalization;
using System.IO;

using Framework.Common;

namespace Framework.Multilanguage
{
    public class ResourceManager
    {
        private string pathstring = string.Empty;

        private CultureInfo _currentCulture;

        private string _fileName = string.Empty;

        private string _path = string.Empty;

        private string FolderPath = string.Empty;

        public SortedList<String, Resources> LanguageResources = new SortedList<String, Resources>();

        /// <summary>
        /// load language xml filename
        /// </summary>
        public string FileName
        {
            get { return _fileName; }
            set { _fileName = value; }
        }

        /// <summary>
        ///   Gets LanguageCode.
        /// </summary>
        public CultureInfo CurrentCulture
        {
            get
            {
                return this._currentCulture;
            }
        }

        public void LoadResources(string path)
        {
            this._path = path;
        }


        /// <summary>
        ///获取浏览器默认语言的相应资源
        /// </summary>
        /// <param name="resourceType"></param>
        /// <param name="resource"></param>
        /// <returns></returns>
        private static Hashtable GetResource(ResourceManagerType resourceType,string resource)
        {
            HttpContext current = HttpContext.Current;
            string language = "zh-CN";
            string defaultLanguage = current.Request.UserLanguages[0].ToString();
            //!容易重复
            string cacheKey = resourceType.ToString() + resource;

            if (string.IsNullOrEmpty(defaultLanguage))
            {
                defaultLanguage = language;
            }
            if (current.Cache[cacheKey] == null)
            {
                Hashtable target = new Hashtable();
                LoadResource(resourceType, resource, target, defaultLanguage, cacheKey);
                //if ("zh-CN" != language)
                //{
                //    LoadResource(resourceType,resource, target, language, cacheKey);
                //}
            }
            return (Hashtable)current.Cache[cacheKey];
        }

        /// <summary>
        /// 获取特定语言的特定资源
        /// </summary>
        /// <param name="resourceType"></param>
        /// <param name="resource"></param>
        /// <param name="language"></param>
        /// <returns></returns>
        private static Hashtable GetResource(ResourceManagerType resourceType, string resource,string language)
        {
            HttpContext current = HttpContext.Current;
            string cacheKey = resourceType.ToString() + language;

            if (!string.IsNullOrEmpty(language))
            {
                throw new Exception(language+"not found!");
            }

            if (current.Cache[cacheKey] == null)
            {
                Hashtable target = new Hashtable();
                LoadResource(resourceType, resource, target, language, cacheKey);
            }
            return (Hashtable)current.Cache[cacheKey];
        }


        /// <summary>
        /// 获取浏览器默认的语言相应的资源
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string GetString(string name)
        {   
            //HttpContext current = HttpContext.Current;
            Hashtable resource = GetResource(ResourceManagerType.String,name);

            string[] str = name.Split('.');
            if (str.Length < 1)
            {
                throw new Exception(name + "not found!");
            }

            if (resource[str[1]] == null)
            {
                throw new Exception("Value not found in Resources.xml for: " + name);
            }
            return (string)resource[str[1]];
            //if (resource[name] == null)
            //{
            //    throw new Exception("Value not found in Resources.xml for: " + name);
            //}
            //return (string)resource[name];
        }

        /// <summary>
        /// 获取指定语言文件的相应资源
        /// </summary>
        /// <param name="name"></param>
        /// <param name="language"></param>
        /// <returns></returns>
        public static string GetString(string name, string language)
        {
            //xHashtable resource = GetResource(ResourceManagerType.String, name);
            Hashtable resource = GetResource(ResourceManagerType.String,name,language);

            string[] str = name.Split('.');
            if (str.Length < 1)
            {
                throw new Exception(name + "not found!");
            }

            if (resource[str[1]] == null)
            {
                throw new Exception("Value not found in Resources.xml for: " + name);
            }
            return (string)resource[str[1]];
        }

        /// <summary>
        /// 获取当前项目支持的所有的语言
        /// </summary>
        /// <returns></returns>
        public static Hashtable GetSupportedLanguages()
        {
            //ForumContext current = ForumContext.Current;
            HttpContext current = HttpContext.Current;
            string key = "Forums-SupportedLanguages";
            if (current.Cache[key] == null)
            {
                string filename = current.Server.MapPath("Languages/languages.xml");
                CacheDependency dependencies = new CacheDependency(filename);
                Hashtable values = new Hashtable();
                XmlDocument document = new XmlDocument();
                document.Load(filename);
                foreach (XmlNode node in document.SelectSingleNode("Resources").ChildNodes)
                {
                    if (node.NodeType != XmlNodeType.Comment)
                    {
                        values.Add(node.Attributes["tag"].Value, node.InnerText);
                    }
                }
                current.Cache.Insert(key, values, dependencies, DateTime.MaxValue, TimeSpan.Zero);
            }
            return (Hashtable)current.Cache[key];
        }

        /// <summary>
        /// 获取xml语言包中的资源项
        /// </summary>
        /// <param name="resourceType"></param>
        /// <param name="target"></param>
        /// <param name="language"></param>
        /// <param name="cacheKey"></param>
        private static void LoadResource(ResourceManagerType resourceType,string resource, Hashtable target, string language, string cacheKey)
        {
            DateTime maxValue;
            //ForumContext current = ForumContext.Current;
            HttpContext current = HttpContext.Current;
            string format = current.Server.MapPath("Languages/" + language + "{0}");
            if (resourceType == ResourceManagerType.ErrorMessage)
            {
                format = string.Format(format, "Messages.xml");
            }
            else
            {
                format = string.Format(format, @".xml");
            }
            CacheDependency dependencies = new CacheDependency(format);

            string [] str = resource.Split('.');
            if (str.Length<1)
            {
                throw new Exception(resource + "not found!");
            }

            #region  XML写法
            XmlDocument document = new XmlDocument();
            try
            {
                document.Load(format);
            }
            catch
            {
                return;
            }
            foreach (XmlNode node in document.SelectSingleNode("Resources").ChildNodes)
            {
                if (node.NodeType != XmlNodeType.Comment)
                {
                    switch (resourceType)
                    {
                        case ResourceManagerType.String:
                            {
                                if (node.Attributes["name"].Value == str[0])
                                {
                                    foreach (XmlNode chil in node)
                                    {
                                        if (chil.Attributes["tag"].Value.ToUpper()==str[1])
                                        {
                                            target[str[1]] = chil.InnerText;
                                        }
                                    }
                                    //xgoto Label_0142;
                                    //xtarget[node.Attributes["name"].Value] = node.InnerText;
                                }
                                //xtarget.Add(node.Attributes["name"].Value, node.InnerText);
                                continue;
                            }
                        case ResourceManagerType.ErrorMessage:
                            {
                                //ForumMessage message = new ForumMessage(node);
                                //target[message.MessageID] = message;
                                continue;
                            }
                    }
                }
                continue;
                //xLabel_0142:
                //xtarget[node.Attributes["name"].Value] = node.InnerText;
            }
    #endregion



            DateTime absoluteExpiration;
            if (language == "zh-CN")
            {
                absoluteExpiration = DateTime.MaxValue;
                current.Cache.Insert(cacheKey, target, dependencies, absoluteExpiration, TimeSpan.Zero);
            }
            absoluteExpiration = DateTime.Now.AddHours(1.0);
        }
           
            //if (language == "zh-CN")
            //{
            //    maxValue = DateTime.MaxValue;
            //}
            //else
            //{
            //    maxValue = DateTime.Now.AddHours(1.0);
            //}
            //current.Cache.Insert(cacheKey, target, dependencies, maxValue, TimeSpan.Zero);

        private enum ResourceManagerType
        {
            String,
            ErrorMessage
        }
    }
            // Nested Types
}
