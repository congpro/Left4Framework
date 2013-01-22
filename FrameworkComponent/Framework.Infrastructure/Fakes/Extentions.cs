using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Framework.Infrastructure.Fakes
{
    public  static class Extentions
    {
        /// <summary>
        /// Indicates whether this context is fake
        /// </summary>
        /// <param name="httpContext">HTTP context</param>
        /// <returns>Result</returns>
        public static bool IsFakeContext(this HttpContextBase httpContext)
        {
            if (httpContext == null)
                throw new ArgumentNullException("httpContext");

            return httpContext is FakeHttpContext;
        }
    }
}
