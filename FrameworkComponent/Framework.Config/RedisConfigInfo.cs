using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.Config
{
    /// <summary>
    /// redis配置类
    /// </summary>
    [Serializable]
    public class RedisConfigInfo : IConfig
    {
        private bool _applyRedis;
        /// <summary>
        /// 是否应用Redis
        /// </summary>
        public bool ApplyRedis
        {
            get
            {
                return _applyRedis;
            }
            set
            {
                _applyRedis = value;
            }
        }

        private string _writeServerList;
        /// <summary>
        /// 可写的Redis链接地址
        /// </summary>
        public string WriteServerList
        {
            get
            {
                return _writeServerList;
            }
            set
            {
                _writeServerList = value;
            }
        }

        private string _readServerList;
        /// <summary>
        /// 可读的Redis链接地址
        /// </summary>
        public string ReadServerList
        {
            get
            {
                return _readServerList;
            }
            set
            {
                _readServerList = value;
            }
        }

        private int _maxWritePoolSize;
        /// <summary>
        /// 最大写链接数
        /// </summary>
        public int MaxWritePoolSize
        {
            get
            {
                return _maxWritePoolSize > 0 ? _maxWritePoolSize : 5;
            }
            set
            {
                _maxWritePoolSize = value;
            }
        }

        private int _maxReadPoolSize;
        /// <summary>
        /// 最大读链接数
        /// </summary>
        public int MaxReadPoolSize
        {
            get
            {
                return _maxReadPoolSize > 0 ? _maxReadPoolSize : 5;
            }
            set
            {
                _maxReadPoolSize = value;
            }
        }

        private bool _autoStart;
        /// <summary>
        /// 自动重启
        /// </summary>
        public bool AutoStart
        {
            get
            {
                return _autoStart;
            }
            set
            {
                _autoStart = value;
            }
        }


        private int _localCacheTime = 30000;
        /// <summary>
        /// 本地缓存到期时间，该设置会与memcached搭配使用，单位:秒
        /// </summary>
        public int LocalCacheTime
        {
            get
            {
                return _localCacheTime;
            }
            set
            {
                _localCacheTime = value;
            }
        }

    }
}
