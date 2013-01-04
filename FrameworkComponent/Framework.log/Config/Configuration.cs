/***********************************************************************
 *  Copyright (C) 2011 Framework Corporation
 *  All rights reserved.
 * 
 *  Author:  Peter.Li
 *  Date:    2011-10-18 09:43:57
 *  Purpose: 
 * 
 * ***********************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;


namespace Framework.log
{
    internal static class Configuration
    {
        private static LogSection _logSection = ConfigurationManager.GetSection(Const.LogSectionPath) as LogSection;

        internal static LogSection LogSection
        {
            get
            {
                return Configuration._logSection;
            }
        }
    }
}
