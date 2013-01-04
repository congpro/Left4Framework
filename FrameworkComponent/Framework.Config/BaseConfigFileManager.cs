using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Framework.Config
{
    /// <summary>
    /// 基本设置信息管理类
    /// </summary>
    class BaseConfigFileManager:DefaultConfigFileManager
    {
        private static BaseConfigInfo _configInfo;

        /// <summary>
        /// 锁对象
        /// </summary>
        private static object m_lockHelper = new object();

        /// <summary>
        /// 文件修改时间
        /// </summary>
        private static DateTime m_fileoldchange;

        /// <summary>
        /// 初始化文件修改时间和对象实例
        /// </summary>
        static BaseConfigFileManager()
        {
            m_fileoldchange = System.IO.File.GetLastWriteTime(ConfigFilePath);
            _configInfo = (BaseConfigInfo)DefaultConfigFileManager.DeserializeInfo(ConfigFilePath, typeof(BaseConfigInfo));
        }

        /// <summary>
        /// 当前配置类的实例
        /// </summary>
        public new static IConfig ConfigInfo
        {
            get { return _configInfo; }
            set { _configInfo = (BaseConfigInfo)value; }
        }

        /// <summary>
        /// 配置文件所在路径
        /// </summary>
        public static string filename = null;

        /// <summary>
        /// 获取配置文件所在路径
        /// </summary>
        public new static string ConfigFilePath
        {
            get
            {
                if (filename == null)
                {
                    filename = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Framework.config");

                    if (!File.Exists(filename))
                    {
                        //utils.ShowErrorPage("发生错误: 网站根目录下没有正确的Framework.config文件");
                        throw new Exception("发生错误: 网站根目录下没有正确的Framework.config文件");
                    }
                }
                return filename;
            }

        }

        /// <summary>
        /// 加载配置类
        /// </summary>
        /// <returns></returns>
        public static BaseConfigInfo LoadConfig()
        {
            ConfigInfo = DefaultConfigFileManager.LoadConfig(ref m_fileoldchange, ConfigFilePath, ConfigInfo);
            return ConfigInfo as BaseConfigInfo;
        }

        /// <summary>
        /// 加载真正有效的配置类
        /// </summary>
        /// <returns></returns>
        public static BaseConfigInfo LoadRealConfig()
        {
            ConfigInfo = DefaultConfigFileManager.LoadConfig(ref m_fileoldchange, ConfigFilePath, ConfigInfo, false);
            return ConfigInfo as BaseConfigInfo;
        }

        /// <summary>
        /// 保存配置
        /// </summary>
        /// <returns></returns>
        public override bool SaveConfig()
        {
            return base.SaveConfig(ConfigFilePath, ConfigInfo);
        }
    }
}
