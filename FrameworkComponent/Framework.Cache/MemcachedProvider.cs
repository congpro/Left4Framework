/***********************************************************************
 *  Copyright (C) 2011 Framework Corporation
 *  All rights reserved.
 * 
 *  Author:  Peter.Li
 *  Date:    2011-12-01 09:43:57
 *  Purpose: 
 * 
 * ***********************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using NorthScale.Store;
using Enyim.Caching.Memcached;
using log4net;
using Couchbase;

namespace Framework.Cache
{
    public class MemcachedProvider : ICache
    {

        private static CouchbaseClient client;

        static MemcachedProvider()
        {
            try
            {
                client = new CouchbaseClient();
            }
            catch (Exception ex)
            {
                log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType).Info("EnyimMemcachedProvider", ex);
            }
        }


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
            throw new NotImplementedException();
        }

        public void Add(string key, object value)
        {
            if (client != null)
            {
                client.Store(StoreMode.Set, key, value);
            }
        }

        public void AddObjectWithTimeout(string key, object value, int timeoutSec)
        {
            if (client != null)
            {
                client.Store(StoreMode.Set, key, value, new TimeSpan(0, 0, timeoutSec));
            }
        }

        public object Get(string key)
        {
            if (client == null)
            {
                return null;
            }
            return client.Get(key);
        }

        public bool TryGet(string key, out object value)
        {
            if (!string.IsNullOrEmpty(key))
            {
                return client.TryGet(key, out value);
            }
            value = null;
            return false;
        }

        public void Remove(string key)
        {
            if (client != null)
            {
                client.Remove(key);
            }
        }

        public bool Contains(string key)
        {
            object value = null;
            return this.TryGet(key, out value);
        }

        public void Clear()
        {
            client.FlushAll();
        }

        public T Get<T>(string strCacheKey)
        {
           return (T)Convert.ChangeType(client.Get(strCacheKey),typeof(T));
        }

        public void ClearCacheByPattern(string pattern)
        {
            if (client != null)
                return;

            object c = client.Get("globel_cacheitems");

            if (c == null)
                return;

            List<string> cacheitems = (List<string>)c;

            foreach (string cacheitem in cacheitems)
            {
                if (cacheitem.StartsWith(pattern))
                {
                    client.Remove(cacheitem);
                }
            }
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
