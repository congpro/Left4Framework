using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.Config
{
    class BaseConfigs
    {
        private static object lockHelper = new object();

        private static System.Timers.Timer baseConfigTimer = new System.Timers.Timer(15000);

        private static BaseConfigInfo _configInfo;

        /// <summary>
        /// 静态构造函数初始化相应实例和定时器
        /// </summary>
        static BaseConfigs()
        {
            _configInfo = BaseConfigFileManager.LoadConfig();
            baseConfigTimer.AutoReset = true;
            baseConfigTimer.Enabled = true;
            baseConfigTimer.Elapsed += new System.Timers.ElapsedEventHandler(Timer_Elapsed);
            baseConfigTimer.Start();
        }

        private static void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            ResetConfig();
        }


        /// <summary>
        /// 重设配置类实例
        /// </summary>
        public static void ResetConfig()
        {
            _configInfo = BaseConfigFileManager.LoadRealConfig();
        }

        public static BaseConfigInfo GetBaseConfig()
        {
            return _configInfo;
        }

        /// <summary>
        /// 返回数据库连接串
        /// </summary>
        public static string GetDBConnectString
        {
            get
            {
                return GetBaseConfig().DBConnectString;
            }
        }


        /// <summary>
        /// 返回模板文件夹名称
        /// </summary>
        public static string GetTemplatePath
        {
            get
            {
                return GetBaseConfig().TemplatePath;
            }
        }

        ///// <summary>
        ///// 返回虚拟路径
        ///// </summary>
        //public static string GetVirtualPath
        //{
        //    get
        //    {
        //        return GetBaseConfig().VirtualPath;
        //    }
        //}

        /// <summary>
        /// 返回数据库类型
        /// </summary>
        public static string GetDbType
        {
            get
            {
                return GetBaseConfig().Dbtype;
            }
        }

        /// <summary>
        /// 保存配置实例
        /// </summary>
        /// <param name="baseconfiginfo"></param>
        /// <returns></returns>
        public static bool SaveConfig(BaseConfigInfo baseconfiginfo)
        {
            BaseConfigFileManager acfm = new BaseConfigFileManager();
            BaseConfigFileManager.ConfigInfo = baseconfiginfo;
            return acfm.SaveConfig();
        }
    }
}
