/******************************************************************************
 *  作者：       [Peter.Li]
 *  创建时间：   2012/4/9 17:39:13
 *
 *
 ******************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.Common.IO
{
    public interface IStorageFolder
    {
        string GetPath();
        string GetName();
        long GetSize();
        DateTime GetLastUpdated();
        IStorageFolder GetParent();
    }
}
