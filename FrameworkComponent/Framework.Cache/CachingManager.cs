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
using System.Configuration;

namespace Framework.Cache
{
    class CachingManager
    {
        private static ICache cs;
        private static volatile CachingManager instance = null;
        private static object lockHelper = new object();

        private CachingManager()
        {
            string type = ConfigurationManager.AppSettings["CacheStrategy"];
            if (type == "2")
                cs = new MemcachedProvider();
            else
                cs = new MemoryProvider();
        }

        public static CachingManager CreateInstance()
        {
            if (instance == null)
            {
                lock (lockHelper)
                {
                    if (instance == null)
                    {
                        instance = new CachingManager();
                    }
                }
            }
            return instance;
        }


        public virtual void AddObject(string key, object value)
        {
            if (String.IsNullOrEmpty(key) || value == null) return;

            lock (lockHelper)
            {
                if (cs.TimeOut <= 0) return;

                cs.Add(key, value);
            }
        }

        public virtual void AddObject(string key, object o, int timeout)
        {
            if (String.IsNullOrEmpty(key) || o == null) return;

            lock (lockHelper)
            {
                if (cs.TimeOut <= 0) return;

                cs.AddObjectWithTimeout(key, o, timeout);
            }
        }

        public virtual void RemoveObject(string key)
        {
            lock (lockHelper)
            {
                cs.Remove(key);
            }
        }

        public virtual object GetObject(string key)
        {
            lock (lockHelper)
            {
                return  cs.Get(key);
            }
        }
    }
}
