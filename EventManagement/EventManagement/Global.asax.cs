using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Http;
using System.Globalization;
using System.Threading;

namespace EventManagement
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);            
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Exception exception = Server.GetLastError();
            Server.ClearError();
            Response.Redirect("/Error/ErrMsg?err=" + string.Join("||", exception.Message.Split(new string[] { Environment.NewLine }, StringSplitOptions.None)));
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            CultureInfo cInfo = new CultureInfo("en-IN");
            cInfo.DateTimeFormat.ShortDatePattern = "MM/dd/yyyy";
            cInfo.DateTimeFormat.DateSeparator = "/";
            Thread.CurrentThread.CurrentCulture = cInfo;
            Thread.CurrentThread.CurrentUICulture = cInfo;
        }

        protected void Application_PostAuthenticateRequest(Object sender, EventArgs e)
        {
            var authCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie != null)
            {
                FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);
                if (authTicket != null && !authTicket.Expired)
                {
                    var roles = authTicket.UserData.Split(',');
                    HttpContext.Current.User = new System.Security.Principal.GenericPrincipal(new FormsIdentity(authTicket), roles);
                }
            }
        }
    }
}