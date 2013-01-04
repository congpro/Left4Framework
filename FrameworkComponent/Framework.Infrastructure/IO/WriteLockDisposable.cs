/******************************************************************************
 *  作者：       Bluexray
 *  创建时间：   2012/4/8 23:43:08
 *
 *
 ******************************************************************************/
using System;
using System.Collections.Generic;
using System.Threading;

namespace Framework.Infrastructure.IO
{
    public class WriteLockDisposable:IDisposable
    {
        private readonly ReaderWriterLockSlim _rwLock;

        /// <summary>
        /// Initializes a new instance of the <see cref="WriteLockDisposable"/> class.
        /// </summary>
        /// <param name="rwLock">The rw lock.</param>
        public WriteLockDisposable(ReaderWriterLockSlim rwLock)
        {
            _rwLock = rwLock;
            _rwLock.EnterWriteLock();
        }

        void IDisposable.Dispose()
        {
            _rwLock.ExitWriteLock();
        }
    }
}
