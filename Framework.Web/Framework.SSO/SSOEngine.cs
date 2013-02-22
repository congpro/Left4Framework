using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using System.Web;
using System.Configuration;

namespace Framework.SSO
{
    public class SSOEngine
    {
           internal static class Constants
        {
            internal const string TokenCookieName = "SSO_Token";
            internal const string AuthUrl = "Auth_Url";
            internal const string RequestToken = "RequestToken";
            internal const string ResponseToken = "ResponseToken";
            internal const string SeedChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890";
        }

        private static string _seed;

        static SSOEngine()
        {
            _seed = NextSeed();
        }

        protected static HttpResponse Response
        {
            get { return HttpContext.Current.Response; }
        }

        protected static HttpRequest Request
        {
            get { return HttpContext.Current.Request; }
        }


        public static bool IsAuthenticated
        {
            get { return GetAuthenticatedTicket() != null; }
        }

        public static bool IsAuthenticating
        {
            get { return !string.IsNullOrEmpty(Request[Constants.ResponseToken]); }
        }

        public static bool Authenticate(out ResponseToken token)
        {
            string tokenText = Request[Constants.ResponseToken];
            if (!ResponseToken.TryParse(tokenText, out token))
                return false;
            if (token.Seed != _seed)
                return false;
            SSOTicket ticket = new SSOTicket();
            ticket.UserId = token.UserId;
            ticket.TimeStamp = token.TimeStamp;
            ticket.ExpireDuration = token.ExpireDuration;
            ResetCookie(Constants.TokenCookieName, ticket.Encode());
            return true;
        }

        public static SSOTicket GetAuthenticatedTicket()
        {
            HttpCookie cookie = Request.Cookies[Constants.TokenCookieName];
            if (cookie == null)
                return null;
            string cookieText = cookie.Value;
            if (string.IsNullOrEmpty(cookieText))
                return null;
            SSOTicket ticket;
            if (!SSOTicket.TryParse(cookieText, out ticket))
                return null;
            return ticket;
        }

        public static RequestToken AuthenticateRequest
        {
            get 
            {
                string tokenText = Request[Constants.RequestToken];
                if (string.IsNullOrEmpty(tokenText))
                    return null;
                RequestToken token;
                if (!RequestToken.TryParse(tokenText, out token))
                    return null;
                return token;
            }
        }

        public static void RedirectToLogon()
        {
            string returnUrl = HttpContext.Current.Request.Url.ToString();
            RequestToken token = new RequestToken(
                returnUrl, 
                DateTime.Now, 
                NextSeed());
            string authUrl = ConfigurationManager.AppSettings[Constants.AuthUrl];
            string redirectUrl = string.Format("{0}?{1}={2}", authUrl, Constants.RequestToken, token.Encode());
            Response.Redirect(redirectUrl);
        }

        public static void RedirectToApp(string returnUrl, ResponseToken token)
        {
            char appendChar = '?';
            if (returnUrl.IndexOf('?') != -1)
                appendChar = '&';
            string redirectUrl = string.Format("{0}{1}{2}={3}", returnUrl, appendChar, Constants.ResponseToken, token.Encode());
            Response.Redirect(redirectUrl);
        }

        private static void ResetCookie(string cookieName, string cookieValue)
        {
            Response.Cookies.Remove(cookieName);
            HttpContext.Current.Response.Cookies[cookieName].Value = cookieValue;
        }

        public static void SignOut()
        {
            HttpContext.Current.Session.Clear();
            HttpContext.Current.Session.Abandon();
            ResetCookie(Constants.TokenCookieName, string.Empty);
        }

        private static string NextSeed()
        {
            Random random = new Random((int)DateTime.Now.Ticks);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 32; i++)
            {
                int idx = random.Next(0, Constants.SeedChars.Length);
                sb.Append(Constants.SeedChars.Substring(idx, 1));
            }
            sb.Append(Guid.NewGuid().ToString());
            return _seed  = SSOEncrypt.Hash(sb.ToString());
        }
    }
}
