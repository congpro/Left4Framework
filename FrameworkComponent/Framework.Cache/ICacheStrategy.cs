using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.Cache
{
    public interface ICacheStrategy
    {
        /// <summary>
        /// 获取此缓存器所缓存项的个数
        /// </summary>
        int Count { get; }

        /// <summary>
        /// 添加一项到缓存器中
        /// </summary>
        /// <param name="key">缓存项的健值</param>
        /// <param name="value">缓存的对象</param>
        /// <param name="cacheDependency">缓存项的过期策略</param>
        void Add(string key, object value, ICacheDependency cacheDependency);

        /// <summary>
        /// 添加一项到缓存器中
        /// </summary>
        /// <param name="key">缓存项的健值</param>
        /// <param name="value">缓存的对象</param>
        /// <remarks>
        /// 没有指定过期策略，则使用永不过期策略缓存
        /// </remarks>
        void Add(string key, object value);



        /// <summary>
        /// 添加一项到缓冲器中
        /// </summary>
        /// <param name="key">缓存的键值</param>
        /// <param name="value">缓存对象</param>
        /// <param name="timeoutSec">过期时间</param>
        void AddObjectWithTimeout(string key, object value, int timeoutSec);

        /// <summary>
        /// 获取缓存项
        /// </summary>
        /// <param name="key">缓存项的健值</param>
        /// <returns>缓存的对象，如果缓存中没有命中，则返回<c>null</c></returns>
        object Get(string key);

        /// <summary>
        /// 尝试获取缓存项，如果存在则返回<c>true</c>
        /// </summary>
        /// <param name="key">缓存项的健值</param>
        /// <param name="value">>缓存的对象，如果缓存中没有命中，则返回<c>null</c></param>
        /// <returns>如果存在则返回<c>true</c></returns>
        bool TryGet(string key, out object value);

        /// <summary>
        /// 移除缓存项
        /// </summary>
        /// <param name="key">缓存项的健值</param>
        void Remove(string key);

        /// <summary>
        /// 判断缓存器中是否包含指定健值的缓存项
        /// </summary>
        /// <param name="key">缓存项的健值</param>
        /// <returns>是/否</returns>
        bool Contains(string key);

        /// <summary>
        /// 清除此缓存器中所有的项
        /// </summary>
        /// <remarks>
        /// 不影响配置文件中其他缓存器
        /// </remarks>
        void Clear();

        /// <summary>
        /// 获取缓存对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="strCacheKey"></param>
        /// <returns></returns>
        T Get<T>(string strCacheKey);


        int TimeOut { set; get; }
    }
}
