using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.Config
{
    [Serializable]
    public class BaseConfigInfo:IConfig
    {
        private string _dbConnectString = string.Empty;
        //private string _virtualPath = string.Empty;
        private string _templatePath = string.Empty;
        private string _dbType = string.Empty;
        private string _viewMode = string.Empty;
        private string _cacheTime = string.Empty;
        private string _language = string.Empty;
        private string _multiLang = "0";

         /// <summary>
        /// 数据库连接字符串
        /// </summary>
        public string DBConnectString
        {
            get { return _dbConnectString; }
            set { _dbConnectString = value; }
        }
        
        /// <summary>
        /// 程序虚拟路径
        /// </summary>
        //public string VirtualPath
        //{
        //    get { return _virtualPath; }
        //    set { _virtualPath = value; }
        //}

        /// <summary>
        /// 程序模板路径
        /// </summary>
        public string TemplatePath
        {
            get { return _templatePath; }
            set { _templatePath = value; }
        }

        /// <summary>
        /// 数据库类型
        /// </summary>
        public string Dbtype
        {
            get { return _dbType; }
            set { _dbType = value; }
        }

        /// <summary>
        /// 页面浏览模式
        /// </summary>
        public string ViewMode
        {
            get { return _viewMode; }
            set { _viewMode = value; }
        }

        /// <summary>
        /// ASPX页面缓存时间
        /// </summary>
        public string CacheTime
        {
            get { return _cacheTime; }
            set { _cacheTime = value; }
        }

        /// <summary>
        /// 后台路径
        /// </summary>
        public string Language
        {
            get { return _language; }
            set { _language = value; }
        }

        /// <summary>
        /// 是否支持多语言
        /// </summary>
        public string MultiLang
        {
            get { return _multiLang; }
            set { _multiLang = value; }
        }
    }
}
