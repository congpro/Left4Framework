/***********************************************************************
 *  Copyright (C) 2011 Framework Corporation
 *  All rights reserved.
 * 
 *  Author:  Peter.Li
 *  Date:    2011-10-22 09:43:57
 *  Purpose: 
 * 
 * ***********************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.IO;

using Framework.Common;

namespace Framework.Config
{
    public class BaseConfigInfoProvider
    {
        private static BaseConfigInfo config = null;

        static BaseConfigInfoProvider()
        {
            config = GetRealBaseConfig();
        }

        /// <summary>
        /// BaseConfigInfo配置。
        /// </summary>
        public static BaseConfigInfo ConfigInfo
        {
            get { return config; }
        }

        /// <summary>
        /// 获取真实基础配置对象
        /// </summary>
        /// <returns></returns>
        public static BaseConfigInfo GetRealBaseConfig()
        {
            BaseConfigInfo newBaseConfig;
            string filename = string.Empty;
            HttpContext context = HttpContext.Current;

            filename = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Framework.config");

            try
            {
                newBaseConfig = (BaseConfigInfo)SerializeHelper.Load(typeof(BaseConfigInfo), filename);
            }
            catch
            {
                newBaseConfig = null;
            }

            if (newBaseConfig == null)
            {
                //utils.ShowErrorPage("发生错误: 网站根目录下没有正确的Framework.config文件");
                throw new Exception("发生错误: 网站根目录下没有正确的Framework.config文件");
            }
            return newBaseConfig;
        }
    }
}
