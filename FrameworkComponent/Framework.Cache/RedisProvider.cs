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
     class RedisProvider :ICache
    {
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
            get { throw new NotImplementedException(); }
        }

        public void Add(string key, object value, ICacheDependency cacheDependency)
        {
            //using (IRedisClient redis = RedisStrategy.Ininit())
            //{
                
            //}
            throw new NotImplementedException();
        }

        public void Add(string key, object value)
        {
            throw new NotImplementedException();
        }

        public void AddObjectWithTimeout(string key, object value, int timeoutSec)
        {
            throw new NotImplementedException();
        }

        public object Get(string key)
        {
            throw new NotImplementedException();
        }

        public bool TryGet(string key, out object value)
        {
            throw new NotImplementedException();
        }

        public void Remove(string key)
        {
            throw new NotImplementedException();
        }

        public bool Contains(string key)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public T Get<T>(string strCacheKey)
        {
            throw new NotImplementedException();
        }

        public int TimeOut
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
    }
}
