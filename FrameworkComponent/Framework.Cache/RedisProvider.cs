/* code by bluexray
 * redis client 4 ServiceStack.Redis
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ServiceStack.Redis;
using ServiceStack.Redis.Support;
using ServiceStack.Text;
using ServiceStack.Redis.Generic;


namespace Framework.Cache
{
    public class RedisProvider :ICache,IDisposable
    {
        private IRedisClient _redis = RedisStrategy.Initialize();

        public object this[string key]
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public object this[string key, ICacheDependency cacheDependency]
        {
            set { throw new NotImplementedException(); }
        }

        public int Count
        {
            get { return this._redis.GetAllKeys().Count; }
        }

        public void Add(string key, object value, ICacheDependency cacheDependency)
        {
            throw new NotImplementedException();
        }

        public void Add(string key, object value)
        {
            this._redis.Set<byte[]>(key, new ObjectSerializer().Serialize(value));
        }

        /// <summary>
        /// 增加一个数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="expireat">过期的时间点</param>
        public void Add<T>(string key, T value, DateTime expireat)
        {
            this._redis.Set(key, value, expireat);
        }

        public void Add<T>(string key, T t)
        {
            this._redis.Set<T>(key, t);
        }   

        public void AddObjectWithTimeout(string key, object value, int timeoutSec)
        {
            throw new NotImplementedException();
        }

        public  object Get(string key)
        {
            return this._redis.Get<object>(key);
        }

        public List<string> GetAllKeys()
        {
            return SearchKeys("*");
        }

        public List<string> SearchKeys(string pattern)
        {
            var result = this._redis.SearchKeys(pattern);
            return result;
        }

        public List<string> GetValues(List<string> keys)
        {
            if (keys == null) throw new ArgumentNullException("keys");
            if (keys.Count == 0) return new List<string>();

            var  results =this._redis.GetValues<string>(keys);

            return results;
        }

        public List<T> GetValues<T>(List<string> keys)
        {
            if (keys == null) throw new ArgumentNullException("keys");
            if (keys.Count == 0) return new List<T>();

            var result = this._redis.GetValues<T>(keys);
            return result;
        }

        public bool Replace<T>(string key, T value)
        {
            var result = this._redis.Replace(key, value);
            return result;
        }

        public bool TryGet(string key, out object value)
        {
            value = this._redis.Get<object>(key);
            return value!=null;
        }

        public void Remove(string key)
        {
            this._redis.Remove(key);
        }

        public bool Contains(string key)
        {
           return this._redis.ContainsKey(key);
        }

        public void Clear()
        {
           this._redis.FlushAll();
        }

        public T Get<T>(string strCacheKey)
        {
          return  this._redis.Get<T>(strCacheKey);
        }

        public int TimeOut
        {
            get
            {
                return 3600;
            }
            set
            {
               this.TimeOut = value;
            }
        }

        public void Dispose()
        {
            if (this._redis!=null)
            {
                this._redis.Dispose();
            }
        }
    }
}
