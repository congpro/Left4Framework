using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace AuthServiceHost
{
    /// <summary>
    /// AuthService 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class AuthService : System.Web.Services.WebService
    {
        /// <summary>
        /// Determines whether user is still logged onto the site
        /// </summary>
        /// <param name="Token"></param>
        /// <returns></returns>
        [WebMethod]
        internal bool IsUserLoggedIn(string Token)
        {
            return HttpContext.Current.Application[Token] != null;
        }



    }
}
