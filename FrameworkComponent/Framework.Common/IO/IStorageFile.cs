/******************************************************************************
 *  作者：       [Peter.Li]
 *  创建时间：   2012/4/9 17:34:27
 *
 *
 ******************************************************************************/
using System;
using System.Collections.Generic;
using System.IO;

namespace Framework.Common.IO
{
    public interface IStorageFile
    {
        string GetPath();
        string GetName();
        long GetSize();
        DateTime GetLastUpdated();
        string GetFileType();

        /// <summary>
        /// Creates a stream for reading from the file.
        /// </summary>
        Stream OpenRead();

        /// <summary>
        /// Creates a stream for writing to the file.
        /// </summary>
        Stream OpenWrite();
    }
}
