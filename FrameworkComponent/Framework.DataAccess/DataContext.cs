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

namespace Framework.DataAccess
{
    public  class DataContext
    {
        public static IDataProvider CreateDefaultInstance()
        {
            return new SQLDataProvider();
        }

        public static IDataProvider CreateInstance(string dataProvider)
        {
            if (dataProvider.ToLower().Trim()=="sql")
            {
                return new SQLDataProvider();
            }
            return null;
        }
    }

    enum DataEngine
    {
        MSSQL=0,
        MYSQL=1,
        ORACLE=2,
        SQLITE=3
    }
}
