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
using System.Web;
using System.Web.Caching;

namespace Framework.Cache
{
    public class DefaultCacheStrategy:ICache
    {
        private static readonly DefaultCacheStrategy instance = new DefaultCacheStrategy();

        protected static volatile System.Web.Caching.Cache webCache = System.Web.HttpRuntime.Cache;

        protected int _timeOut = 1; //默认缓存一分钟，也可以单独设置对象的超时时间

        public int TimeOut
        {
            set { _timeOut = value > 0 ? value : 6000; }
            get { return _timeOut > 0 ? _timeOut : 6000; }
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


        public static System.Web.Caching.Cache GetWebCacheObj
        {
            get { return webCache; }
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
            if (key == null || key.Length == 0 || value == null)
            {
                return;
            }

            CacheItemRemovedCallback callBack = new CacheItemRemovedCallback(onRemove);

            if (TimeOut == 6000)
            {
                webCache.Insert(key, value, null, DateTime.MaxValue, TimeSpan.Zero, System.Web.Caching.CacheItemPriority.High, callBack);
            }
            else
            {
                webCache.Insert(key, value, null, DateTime.Now.AddMinutes(TimeOut), System.Web.Caching.Cache.NoSlidingExpiration, System.Web.Caching.CacheItemPriority.High, callBack);
            }
        }

        public object Get(string key)
        {
            if (key == null || key.Length == 0)
            {
                return null;
            }

            return webCache.Get(key);
        }

        public bool TryGet(string key, out object value)
        {
            if (key != null || key.Length != 0)
            {
                if (webCache.Get(key) != null)
                {
                    value = webCache.Get(key);
                    return true;
                }
            }
            value = null;
            return false;
        }

        public void Remove(string key)
        {
            //objectTable.Remove(objId);
            if (key == null || key.Length == 0)
            {
                return;
            }
            webCache.Remove(key);
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


        public void onRemove(string key, object val, CacheItemRemovedReason reason)
        {
            switch (reason)
            {
                case CacheItemRemovedReason.DependencyChanged:
                    break;
                case CacheItemRemovedReason.Expired:
                    {
                        //CacheItemRemovedCallback callBack = new CacheItemRemovedCallback(this.onRemove);

                        //webCache.Insert(key, val, null, System.DateTime.Now.AddMinutes(TimeOut),
                        // System.Web.Caching.Cache.NoSlidingExpiration,
                        // System.Web.Caching.CacheItemPriority.High,
                        // callBack);
                        break;
                    }
                case CacheItemRemovedReason.Removed:
                    {
                        break;
                    }
                case CacheItemRemovedReason.Underused:
                    {
                        break;
                    }
                default: break;
            }

            //TODO: write log here
        }

        /// <summary>
        /// 添加缓存和过期时间
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="timeoutSec"></param>
        public void AddObjectWithTimeout(string key, object value, int timeoutSec)
        {
            if (key == null || key.Length == 0 || value == null || timeoutSec <= 0)
            {
                return;
            }

            CacheItemRemovedCallback callBack = new CacheItemRemovedCallback(onRemove);

            webCache.Insert(key, value, null, System.DateTime.Now.AddSeconds(timeoutSec), System.Web.Caching.Cache.NoSlidingExpiration, System.Web.Caching.CacheItemPriority.High, callBack);
        }

    }
}
