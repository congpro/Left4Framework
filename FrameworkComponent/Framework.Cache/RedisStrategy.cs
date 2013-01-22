using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;


using Framework.Config;
using ServiceStack.Redis;
using ServiceStack.Redis.Generic;
using ServiceStack.Redis.Support;
using Framework.Common;

namespace Framework.Cache
{
    public sealed class RedisStrategy : ICacheStrategy
    {
       /// <summary>
       /// 配置文件所在路径
       /// </summary>
       public  static string filename = null;

       private static RedisConfigInfo redisConfigInfo;

       private static PooledRedisClientManager prcm;

        private static string ConfigPath 
        {
            get
            {
                if (filename == null)
                {
                    HttpContext context = HttpContext.Current;
                    if (context != null)
                    {
                        filename = context.Server.MapPath("~/redis.config");
                        if (!File.Exists(filename))
                        {
                            filename = context.Server.MapPath("/redis.config");
                        }
                    }
                    else
                    {
                        filename = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "redis.config");
                    }

                    if (!File.Exists(filename))
                    {
                        throw new FileLoadException("发生错误: 虚拟目录或网站根目录下没有正确的Redis.config文件");
                    }
                }
                return filename;
            }   
        }



        public static  IRedisClient Initialize()
        {
            GetRedisConfig();

           if (prcm == null)
               CreateManager();

           return prcm.GetClient();
       }

       /// <summary>
       /// 创建链接池管理对象
       /// </summary>
       private static void CreateManager()
       {
           string[] writeServerList = UtilsHelper.SplitString(redisConfigInfo.WriteServerList, ",");
           string[] readServerList = UtilsHelper.SplitString(redisConfigInfo.ReadServerList, ",");

           prcm = new PooledRedisClientManager(readServerList, writeServerList,
                            new RedisClientManagerConfig
                            {
                                MaxWritePoolSize = redisConfigInfo.MaxWritePoolSize,
                                MaxReadPoolSize = redisConfigInfo.MaxReadPoolSize,
                                AutoStart = redisConfigInfo.AutoStart,
                            });
       }

        private static void GetRedisConfig()
        {
            if (UtilsHelper.FileExists(ConfigPath))
            {
                redisConfigInfo = SerializeHelper.GetDeserializedObject<RedisConfigInfo>(ConfigPath);
            }
            else
            {
                throw new FileLoadException("发生错误: 虚拟目录或网站根目录下没有正确的Redis.config文件");
            }
        }
    }
}
